using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerDetailsUI : MonoBehaviour
{

    //UI Slider Health
    public Slider healthSlider;
    [HideInInspector]
    public float healthSliderControl;

    //UI ShowLivesText & Lives
    public int lives = 3;
    [SerializeField]
    private Text livesText;
    [HideInInspector]
    public bool ShowLives;

    // UI ScoreText 
    [HideInInspector]
    public int scoredEnemies;
    public Text ScoreText;

    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Player Health
        healthSlider.value = Mathf.MoveTowards(healthSlider.value, healthSliderControl, 50 * Time.deltaTime);

        // Player Score
        ScoreText.text = $"SCORE: {scoredEnemies.ToString()}\nHSCORE: {PlayerPrefs.GetInt("HIGHSCORE").ToString()}";
        
        // Player Lives
        if (ShowLives == true)
        {
            Debug.Log("sdfsdf");
            livesText.text = $"{lives.ToString()} X";
            ShowLives = false;
        }
        if (lives == 0)
        {
            if(scoredEnemies > PlayerPrefs.GetInt("HIGHSCORE"))
            {
                PlayerPrefs.SetInt("HIGHSCORE", scoredEnemies);
            }
            gameManager.GameOver();
        }
    }

   
}
