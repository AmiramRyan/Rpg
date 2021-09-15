using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNpc : Interactable
{
    [SerializeField] private TextAssetValue dialogVal;
    //reff to the npc dialog
    [SerializeField] private TextAsset dialogAsset;
    //notification to send to the canvases to activate and check

    //dialog
    [SerializeField] private Signal branchingDialogSignal;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("check"))
            {
                dialogVal.Value = dialogAsset;
                branchingDialogSignal.Rise();
            }
        }
    }
}
