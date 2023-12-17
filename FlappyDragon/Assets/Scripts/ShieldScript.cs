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
        if (CollisionDetector.touched)
        {
            shield.SetActive(false);
            isShieldActive = false;
            CollisionDetector.touched = false;
        }
        
    }

    IEnumerator closeShield()
    {
        yield return new WaitForSeconds(7);
        shield.SetActive(false);
        isShieldActive = false;
        Debug.Log("Kapandi");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.CompareTag("ShieldIcon")) && (!isShieldActive) && (!SpeedScript.isSpeedActive))
        {
            shield.SetActive(true);
            isShieldActive = true;
            StartCoroutine(closeShield());
            collision.gameObject.SetActive(false);
            Debug.Log("Açýldý");

        }
    }
}
