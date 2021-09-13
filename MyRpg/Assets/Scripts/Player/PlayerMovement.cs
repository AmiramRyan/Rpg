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
    [Header("Vars")]
    public float playerSpeed;
    public float attackCooldown;
    public VectorValue startPos;

    [Header("Objects Ref")]
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;

    public PlayerState currentState;


    //todo Hp
    public Signal playerHpSignal;
    public FloatValue currentHealth;
    private Vector3 change;

    //todo inventory
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;

    //todo player hit mybe on hp
    public Signal playerHit;

    //todo magic
    public FloatValue currentMp;
    public Signal playerMpSignal;
    //todo ability
    public Item playerBow;
    private bool haveBow;
    public GameObject arrowProj;


    void Start()
    {
        haveBow = CheckItem(playerBow);
        currentState = PlayerState.walk;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        transform.position = startPos.defaultValue;
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
        else if (Input.GetButtonDown("2ndattack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (!haveBow)
            {
                haveBow = CheckItem(playerBow);
            }
            if (haveBow)
            {
                StartCoroutine(SecondAttackCo());
            }
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
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
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

    //todo move knockto its own script
    private IEnumerator knockCo(float knockTime)
    {
        //todo hp
        playerHit.Rise();
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }

    private IEnumerator SecondAttackCo()
    {
        if (currentMp.runTimeValue > 0)
        {
            currentState = PlayerState.attack;
            yield return null;
            //todo ploymorph this from arrow to ability in general
            Vector2 temp = new Vector2(myAnimator.GetFloat("moveX"), myAnimator.GetFloat("moveY"));
            Arrow arrow = Instantiate(arrowProj, transform.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.Fire(ChooseArrowDirection(), temp);
            currentMp.runTimeValue--; //update costs later!!
            //todo mp
            playerMpSignal.Rise();
            yield return new WaitForSeconds(attackCooldown);
            if (currentState != PlayerState.interact)
            {
                currentState = PlayerState.walk;
            }
        }
    }

    //todo move knockto its own script
    public void Knock(float knockTime , float dmg)
    {
        currentHealth.runTimeValue -= dmg;
        //todo hp
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

    private Vector3 ChooseArrowDirection()
    {
        float rotation = Mathf.Atan2(myAnimator.GetFloat("moveY"), myAnimator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, rotation);
    }

    public bool CheckItem(Item item)
    {
        if (playerInventory.inventoryList.Contains(item))
        {
            return true;
        }
        return false;
    }
}
