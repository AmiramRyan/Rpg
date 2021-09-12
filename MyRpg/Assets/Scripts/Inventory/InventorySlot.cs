using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Item Slot in the Ui")]
    [SerializeField] private Text itemCounterText;
    [SerializeField] private Image itemImg;

    [Header("Vars")]
    public InventoryItem thisItem;
    public InventoryManager invManager;

    public void SetUp(InventoryItem item, InventoryManager manager)
    {
        thisItem = item;
        invManager = manager;
        if (thisItem)
        {
            itemImg.sprite = thisItem.itemImg; //show correct img
            itemCounterText.text = "" + thisItem.numberInInv; // show correct qunatity
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
