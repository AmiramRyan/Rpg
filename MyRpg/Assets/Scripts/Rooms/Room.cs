using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemiesArr;
    public Pot[] potsArr;
    public GameObject virtualCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {

            //enable arrays
            for(int i = 0; i< enemiesArr.Length; i++)
            {
                ChangeActive(enemiesArr[i], true);
            }
            for (int i = 0; i < potsArr.Length; i++)
            {
                ChangeActive(potsArr[i], true);
            }
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

    public void ChangeActive(Component component,bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
