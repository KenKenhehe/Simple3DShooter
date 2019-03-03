using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpStrength;
    public GameObject bulletPref;
    public Action OnHitObstatle;
    public Action OnHitOrb;

    int dir;
    bool isGrounded;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        dir = 1;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ProcessInput();
        
	}

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, jumpStrength, 0));
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir = 1;
            rb.velocity = new Vector3(speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir = -1;
            rb.velocity = new Vector3(-speed * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject bulletObj = Instantiate<GameObject>(bulletPref);
            bulletObj.transform.position = transform.position;
            BulletController bullet = bulletObj.GetComponent<BulletController>();
            bullet.Dir = dir;
           
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ObstacleController>() != null)
        {
            Destroy(gameObject);
            OnHitObstatle();
        }

        if(other.GetComponent<OrbController>() != null)
        {
            OnHitOrb();
        }
    }
}
