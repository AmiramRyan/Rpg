using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public Signal clueSignal;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void OnTriggerExit2D(Collider2D other)
    {
        if (playerInRange)
        {
            if (other.CompareTag("Player") && other.isTrigger)
            {
                clueSignal.Rise();
                playerInRange = false;
            }
        }
    }
}
