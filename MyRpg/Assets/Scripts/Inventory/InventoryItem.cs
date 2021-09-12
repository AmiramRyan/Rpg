using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//the blueprint and all the data an item needs
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string description;
    public int numberInInv; //if not unique can stack
    public bool usable; //can press ues to do somthing with
    public bool unique; //can only have 1 of those
    public Sprite itemImg;
    public UnityEvent thisEvent;

    public void Use()
    {
        Debug.Log("Ues Item");
        thisEvent.Invoke();
    }
}
