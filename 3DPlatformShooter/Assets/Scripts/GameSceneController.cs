using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {
    public Camera mainCamera;
    public PlayerController player;
    public Text gameText;
    bool gameOver;
	// Use this for initialization
	void Start () {
        gameOver = false;
        Time.timeScale = 1;
        player.OnHitObstatle = () =>
        {
            OnGameOver(false);
        };
        player.OnHitOrb = () => {
            OnGameOver(true);
        };
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R) && gameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (player != null)
        {
            AlignWithCamera();
        }
	}

    void AlignWithCamera()
    {
        mainCamera.transform.position = new Vector3(
            Mathf.Lerp(mainCamera.transform.position.x, player.transform.position.x, Time.deltaTime * 2),
            Mathf.Lerp(mainCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 2),
            mainCamera.transform.position.z
            );
    }

    void OnGameOver(bool win)
    {
        gameOver = true;
        if(win == true)
        {
            Time.timeScale = 0;
            gameText.text = "you win!!";
        }
        else  if(win == false)
        {
            gameText.text = "game Over";
        }

        
    }
}
