using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIfollowwall : MonoBehaviour
{
    public Vector3 moveDestination;
    public bool isMoving;
    public float moveSpeed = 1;
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

        void Flip()
    {
       // facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Update()
    {
        transform.LookAt(moveDestination);
        if (transform.position.x == moveDestination.x && transform.position.z == moveDestination.z)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        if (isMoving == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (Physics.Raycast(transform.position, -transform.right, out hit))
                {
                    transform.LookAt(transform.position + (-transform.right));
                }
                else
                {
                    transform.LookAt(transform.position + (-transform.right));
                }
            }
            else
            {
                moveDestination = transform.position + (transform.forward);
            }
        }
    }

    void FixedUpdate()
    {
        rb2D.AddForce(transform.up * moveSpeed);
    }
}