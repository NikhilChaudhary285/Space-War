using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOver;  
    private float delayedGameOverTime = 1f;
    public void GameOver()
    {
        Invoke("DelayedGameOver", delayedGameOverTime);
    }

    void DelayedGameOver()
    {
        // Start gameOver animation and then go to Restart_Game in RestartGame Script to Restart Game
        gameOver.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // Back Button was pressed!
            Application.Quit();
        }
    }
}
