using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Animator animator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            //rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
            rb.velocity = new Vector3(0, 4f, 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 2.5f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, -2.5f) * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            rb.transform.Rotate(new Vector3(0, 0, 0));
        }*/
    }
    private void FixedUpdate()
    {
        
        
    }
}
