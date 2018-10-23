using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject shield;
    public GameObject burst;

    Animator animator;
    Rigidbody2D rigidBody2D;
    float inputX;
    float inputY;
    bool isWalking;
    bool isShielding;

	void Start () {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        isWalking = (Mathf.Abs(inputX) + Mathf.Abs(inputY) > 0);

        animator.SetBool("isWalking", isWalking);

        if(isWalking)
        {
            animator.SetFloat("x", inputX);
            animator.SetFloat("y", inputY);
        }

        // Burst test
        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(burst, transform.position, transform.rotation);
        }

        // Shield
        if (Input.GetMouseButtonDown(1))
        {
            isShielding = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isShielding = false;
        }
        if(isShielding)
        {
            shield.SetActive(true);
        } else
        {
            shield.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rigidBody2D.AddForce(new Vector2(inputX, inputY).normalized * speed, ForceMode2D.Force);
    }
}
