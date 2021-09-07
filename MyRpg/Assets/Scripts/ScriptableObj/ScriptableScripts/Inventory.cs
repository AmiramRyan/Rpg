using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> inventoryList = new List<Item>();
    public int numOfKeys;
    public int coins;

    

    public void AddToInv(Item itemToAdd)
    {
        //is it key?
        if (itemToAdd.isKey)
        {
            numOfKeys++;
        }
        else // add to inventory if we dont already have one
        {
            if (!inventoryList.Contains(itemToAdd))
            {
                inventoryList.Add(itemToAdd);
            }
        }
    }

    
}
