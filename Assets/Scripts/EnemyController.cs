using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    Animator animator;
    Rigidbody2D rigidBody2D;
    Vector2 target;
    bool isWalking;
    float vectorX;
    float vectorY;

    void Start () {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        StartCoroutine("GetNextMove");
    }
	
	void Update () {
        Debug.DrawRay(transform.position, new Vector3(target.x, target.y, 0), Color.green);
        animator.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            animator.SetFloat("x", vectorX);
            animator.SetFloat("y", vectorY);
        }
    }

    void FixedUpdate()
    {
        rigidBody2D.AddForce(target.normalized * speed, ForceMode2D.Force);
    }

    IEnumerator GetNextMove()
    {
        for (;;)
        {
            int random = Random.Range(0, 3);
            if (random < 2)
            {
                // 2 over 3 chances to get a new destination
                target = Random.insideUnitCircle * 3;
                vectorX = target.normalized.x;
                vectorY = target.normalized.y;
                isWalking = true;
            } else
            {
                // 1 over 3 chance to stop
                target = Vector2.zero;
                isWalking = false;
            }
            
            // execute this every 2 seconds
            yield return new WaitForSeconds(2f);
        }
    }
}
