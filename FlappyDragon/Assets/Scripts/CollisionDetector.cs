using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Text score, highscore, currentscore;
    public static int scoreF;
    public static bool touched;

    
    void Start()
    {
        score.text = string.Empty;
        scoreF = 0;
        GameOverScreen.SetActive(false);
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        { 
            touched = true;
            if (!ShieldScript.isShieldActive && !SpeedScript.isSpeedActive)
            {
                GameOverScreen.SetActive(true);
                currentscore.text = scoreF.ToString();
                highscore.text = PlayerPrefs.GetInt("highScore").ToString();
                
                Time.timeScale = 0;
            }
            
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointArea"))
        {
            scoreF += 1;
            score.text = scoreF.ToString();
            
        }
    }
}
