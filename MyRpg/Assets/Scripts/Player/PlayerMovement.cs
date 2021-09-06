using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class PlayerMovement : MonoBehaviour
{
    #region Public vars
    [Header("Vars")]
    public float playerSpeed;
    public float attackCooldown;
    public FloatValue currentHealth;
    public Signal playerHpSignal;
    public VectorValue startPos;

    [Header("Objects Ref")]
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;

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
        transform.position = startPos.runTimeValue;
    }


    void FixedUpdate()
    {
        if (currentState == PlayerState.interact)
        {
            return; //dont do anything
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (currentState == PlayerState.walk || currentState == PlayerState.idle) { 
            PlayAnimationsAndMove(); 
        }
    }

    private void Update()
    {
        //Player interactions
        if(currentState == PlayerState.interact)
        {
            return; //dont do anything
        }
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
    }
    void MoveCharacter()
    {
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
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator knockCo(float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }

    public void Knock(float knockTime , float dmg)
    {
        currentHealth.runTimeValue -= dmg;
        playerHpSignal.Rise();
        if (currentHealth.runTimeValue > 0)
        {
            StartCoroutine(knockCo(knockTime));
        }
        else
        {
            Debug.Log("player death");
            this.gameObject.SetActive(false);
        }
    }
    #endregion

    public void GetItems()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                myAnimator.SetBool("isHoldingItem", true);
                currentState = PlayerState.interact;
                receiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                myAnimator.SetBool("isHoldingItem", false);
                currentState = PlayerState.idle;
                receiveItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }
}
