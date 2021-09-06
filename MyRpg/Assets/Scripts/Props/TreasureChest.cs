using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Inventory playerInv;
    public Item contents;
    public bool isOpen;
    public Signal getItemSignal;
    public GameObject textBubble;
    public Text dialogText;
    private Animator chestAnim;
    public bool activeChest;

    void Start()
    {
        chestAnim = GetComponent<Animator>();
        isOpen = false;
        activeChest = true;
    }


    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                if (!isOpen)
                {
                    // open the chest  + animation
                    OpenChest();
                    //give item
                }
                else
                {
                    IsAlreadyOpen();
                }
            }
    }

    public void OpenChest()
    {
        //open dialog box and say somthing
        textBubble.SetActive(true);
        dialogText.text = contents.relatedText;
        //add item to player inventory
        playerInv.AddToInv(contents);
        playerInv.currentItem = contents;
        //play holding item anim
        getItemSignal.Rise();
        //set chest to open state
        isOpen = true;
        //context clue off
        clueSignal.Rise();
        activeChest = false;
        chestAnim.SetBool("isOpen", true);
    }
    
    public void IsAlreadyOpen()
    {
            //dialog off 
            textBubble.SetActive(false);
            //rise signal to stop animating player
            getItemSignal.Rise();
            activeChest = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            if (!playerInRange)
            {
                if (activeChest)
                {
                    clueSignal.Rise();
                }
                playerInRange = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            if (playerInRange)
            {
                if (activeChest)
                {
                    clueSignal.Rise();
                }
                playerInRange = false;
            }
        }
    }


}
