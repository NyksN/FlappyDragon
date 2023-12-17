using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    Animator animator;
    public static bool isSpeedActive;
    Rigidbody2D rb;
    public static float pipeSpeedmax;
    public static float pipeSpeedmin;
    
    void Start()
    {
        isSpeedActive = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(closeSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpeedActive)
        {
            PipesMovement.speed = 3.5f;
            pipeSpeedmax = 1.39f;
            pipeSpeedmin = 1.04f;
        }
        else
        {
            pipeSpeedmax = 3.2f;
            pipeSpeedmin = 2.4f;
            PipesMovement.speed = 1.5f;
        }
       
          
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedIcon")&&!isSpeedActive)
        {
            StartCoroutine(closeSpeed());
            animator.SetBool("SpeedIconTaked", true);
            isSpeedActive = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            

        }
    }

    IEnumerator closeSpeed()
    {
        yield return new  WaitForSeconds(7);
        animator.SetTrigger("SpeedFinish");
        animator.SetBool("SpeedIconTaked", false);
        isSpeedActive = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;

    }
    
}
