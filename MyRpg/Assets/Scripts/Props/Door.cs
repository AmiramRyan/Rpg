using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : Interactable
{

    // Start is called before the first frame update
    void Start()
    {
        activeObj = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void  OpenDoor()
    {
        //change sprite
        //set door to open

    }
    public virtual void CloseDoor()
    {

    }
}
