using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject GameOverScreen;
    public static bool touched;
    void Start()
    {
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
            if (!ShieldScript.isShieldActive)
            {
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
            
            
            
        }
    }
}
