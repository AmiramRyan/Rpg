using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    
    public string whatDoseTheSignSay;
    public Text dialogText;
    public GameObject dialogBox;



    // Update is called once per frame
    public void  Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = whatDoseTheSignSay;
                }
            }
    }  
    public override void OnTriggerExit2D(Collider2D other)
    {
        if (playerInRange)
        {
            if (other.CompareTag("Player") && other.isTrigger)
            {
                if (activeObj)
                {
                    clueSignal.Rise();
                }
                playerInRange = false;
                dialogBox.SetActive(false);
            }
        }
    }
    
}
