using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : DungeonRoom
{
    public Door[] doorsToInteract;
    
    public void CheckRoomClear() //itrate enemies array to see if all have been defeated
    {
        for(int i =0; i<enemiesArr.Length-1; i++)
        {
            if(enemiesArr[i].gameObject.activeInHierarchy && i < enemiesArr.Length -1)
            {
                return;
            }
        }
        OpenAllDoors();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //enable arrays
            for (int i = 0; i < enemiesArr.Length; i++)
            {
                ChangeActive(enemiesArr[i], true);
            }
            for (int i = 0; i < potsArr.Length; i++)
            {
                ChangeActive(potsArr[i], true);
            }
            CloseAllDoors();
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //dissable arrays
            for (int i = 0; i < enemiesArr.Length; i++)
            {
                ChangeActive(enemiesArr[i], false);
            }
            for (int i = 0; i < potsArr.Length; i++)
            {
                ChangeActive(potsArr[i], false);
            }
        }
        virtualCam.SetActive(false);
    }


    public void OpenAllDoors()
    {
        for(int i = 0; i<doorsToInteract.Length; i++)
        {
            doorsToInteract[i].OpenDoor();
        }

    }

    public void CloseAllDoors()
    {
        for (int i = 0; i < doorsToInteract.Length; i++)
        {
            doorsToInteract[i].CloseDoor();
        }

    }
}
