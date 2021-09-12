using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//create inventory slots and show them on the ui with the correct discription and ues button
public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInv;

    [SerializeField] private GameObject blankInvSlot;
    [SerializeField] private GameObject invPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject uesBtn;
    public InventoryItem currentItem;

    public void SetTxtNBtn(string descrip, bool btnActive)
    {
        descriptionText.text = descrip;
        if (btnActive)
        {
            uesBtn.SetActive(true);
        }
        else
        {
            uesBtn.SetActive(false);
        }
    }

    void Start()
    {
        CreateInvSlots();
        SetTxtNBtn("", false);
    }

    void CreateInvSlots()
    {
        if (playerInv)
        {
            for(int i = playerInv.playerInv.Count - 1; i>=0 ; i--)
            {
                GameObject temp = Instantiate(blankInvSlot, invPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(invPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.SetUp(playerInv.playerInv[i], this);
                }
            }
        }
    }

    public void SetItemInfo(string description, bool isUesable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = description;
        uesBtn.SetActive(isUesable);
    }

    public void UesBtn()
    {
        if (currentItem)
        {
            currentItem.Use();
        }
    }
}
