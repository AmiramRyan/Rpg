using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractClue : MonoBehaviour
{
    public GameObject interactBox;

    public void Enable()
    {
        interactBox.SetActive(true);
    }

    public void Disable() 
    {
        interactBox.SetActive(false);
    }
}
