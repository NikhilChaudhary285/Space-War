using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private bool gameHasEnded = true;
    private float restartDelay = 1f;

    public void Restart_Game()
    {
        if (gameHasEnded == true)
        {
            Invoke("Restart", restartDelay);
            gameHasEnded = false;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
