using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory/player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> playerInv = new List<InventoryItem>();

   
}
