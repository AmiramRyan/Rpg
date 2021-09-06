using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Key : Door
{
    public Inventory playerInv;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                if (playerInv.numOfKeys > 0)
                {
                    playerInv.numOfKeys--;
                    OpenDoor();
                }
            }
            else
            {
               
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerInRange)
        {
            if (other.CompareTag("Player") && other.isTrigger)
            {
                clueSignal.Rise();
                playerInRange = true;
                
            }
        }
    }
}
