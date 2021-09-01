using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public vars
    public float playerSpeed;
    public Rigidbody2D myRigidBody;

    #endregion

    #region Private vars

    private Vector3 change;

    #endregion

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        change = Vector3.zero; //reset the change 
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change * playerSpeed * Time.deltaTime);
    }
}
