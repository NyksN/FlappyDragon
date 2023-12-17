using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float highScore;
    
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        highScore = PlayerPrefs.GetInt("highScore");
        if(CollisionDetector.scoreF > highScore)
        {
            PlayerPrefs.SetInt("highScore", CollisionDetector.scoreF);
        }
        
    }
}
