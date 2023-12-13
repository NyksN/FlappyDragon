using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{
    Rigidbody2D dragonRB;
    public float jumpForce, rotationSpeed;
    Animator animator;
    

    void Start()
    {
     dragonRB = GetComponent<Rigidbody2D>();
     animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Falling", false);
            dragonRB.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jumped");
            
        }
        if(dragonRB.velocity.y <0)
        {
            animator.SetBool("Falling",true);

        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, dragonRB.velocity.y * rotationSpeed);
    }
}
