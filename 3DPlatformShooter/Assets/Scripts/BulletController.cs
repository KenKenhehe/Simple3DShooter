using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    
    public float bulletSpeed;
    public int Dir = 1;

    Rigidbody rb;
    float lifeTime;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
        lifeTime += Time.deltaTime;
        if(lifeTime >= 5)
        {
            Destroy(gameObject);
        }
	}

    void Shoot()
    {
        rb.velocity = new Vector3(bulletSpeed * Dir * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ObstacleController>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
