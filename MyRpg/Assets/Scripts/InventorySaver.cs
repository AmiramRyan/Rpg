using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class InventorySaver : MonoBehaviour
{
    [SerializeField] private PlayerInventory myInv;

    private void OnEnable()
    {
        myInv.playerInv.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }


    public void Reset() 
    {
        int i = 0;
           while(File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
                File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            i++;
        }
    }


    public void SaveScriptables()
    {
        Reset();
        for (int i = 0; i < myInv.playerInv.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath +
                string.Format("/{0}.inv", i)); //saves as {I}Object.dat
            //create a binary formater to read
            BinaryFormatter formatter = new BinaryFormatter();
            var json = JsonUtility.ToJson(myInv.playerInv[i]);
            //save the data in the file
            formatter.Serialize(file, json);
            //close dataStream
            file.Close();
        }
    }
    public void LoadScriptables()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            {
                var temp = ScriptableObject.CreateInstance<InventoryItem>();
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), temp); // formater take data in a json string and convert it  
                file.Close();
                myInv.playerInv.Add(temp);
                i++;
            }
        }
    }

    /*public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + string.Format("/{0}Object.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}Object.dat", i), FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), objects[i]); // formater take data in a json string and convert it  
                file.Close();
            }
        }
    }*/
}
