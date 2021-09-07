using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Interactable
{
    public Signal powerupSignal;
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerInRange)
        {
            if (other.CompareTag("Player") && other.isTrigger)
            {
                if (activeObj)
                {
                    powerupSignal.Rise();
                    activeObj = false;
                    Destroy(this.gameObject);
                }
                playerInRange = true;
            }
        }
    }
}
