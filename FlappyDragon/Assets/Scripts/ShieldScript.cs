using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public GameObject shield;
    public static bool isShieldActive;
    void Start()
    {
       shield.SetActive(false);
       isShieldActive = false;
       StartCoroutine(closeShield());
    }

    // Update is called once per frame
    void Update()
    {
        if(CollisionDetector.touched)
        {
            shield.SetActive(false);
            isShieldActive = false;
            CollisionDetector.touched = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && !isShieldActive)
        {
            shield.SetActive(true); 
            isShieldActive = true;
            StartCoroutine (closeShield());
        } 
    }
    
    IEnumerator closeShield()
    {
       yield return new WaitForSeconds(7);
        shield.SetActive(false);
        isShieldActive=false;
    }
}
