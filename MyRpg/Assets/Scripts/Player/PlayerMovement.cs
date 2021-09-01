using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}
public class PlayerMovement : MonoBehaviour
{
    #region Public vars
    [Header("Vars")]
    public float playerSpeed;
    public float attackCooldown;

    [Header("Objects Ref")]
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;

    public PlayerState currentState;

    #endregion

    #region Private vars

    private Vector3 change;

    #endregion

    void Start()
    {
        currentState = PlayerState.walk;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("moveX", 0);
        myAnimator.SetFloat("moveY", -1);
    }

    private void Update()
    {
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (currentState == PlayerState.walk) { 
            PlayAnimationsAndMove(); 
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * playerSpeed * Time.deltaTime);
    }

    void PlayAnimationsAndMove()
    {
        if (change != Vector3.zero)
        {
            currentState = PlayerState.walk;
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

    #region Coroutines
    private IEnumerator AttackCo()
    {
        myAnimator.SetBool("isAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        myAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(attackCooldown);
        currentState = PlayerState.walk;
    }

    #endregion
}
