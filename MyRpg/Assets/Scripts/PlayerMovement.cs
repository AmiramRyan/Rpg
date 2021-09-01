using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public vars
    [Header("Vars")]
    public float playerSpeed;

    [Header("Objects Ref")]
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;

    #endregion

    #region Private vars

    private Vector3 change;

    #endregion

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        change = Vector3.zero; //reset the change 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        PlayAnimationsAndMove();
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * playerSpeed * Time.deltaTime);
    }

    void PlayAnimationsAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            myAnimator.SetBool("isMoving", true);
            myAnimator.SetFloat("moveX", change.x);
            myAnimator.SetFloat("moveY", change.y);

        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
    }
}
