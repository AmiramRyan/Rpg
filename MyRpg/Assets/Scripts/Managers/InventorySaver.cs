using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class InventorySaver : MonoBehaviour
{
    public PlayerInventory myInv;
    public static InventorySaver invSaver;
    void Awake()
    {
        //making sure there is only one of this classes as objects
        if (!invSaver)
        {
            DontDestroyOnLoad(this.gameObject);
            invSaver = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
    }

    private void OnEnable()
    {
        myInv.playerInv.Clear();
        Load();
    }

    public void Save()
    {
        for (int i = 0; i < myInv.playerInv.Count; i++)
        {
            //create a binary formater to read
            BinaryFormatter formatter = new BinaryFormatter();

            //create routh from program to file
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i)); //saves as {I}.inv

            //create copy of my save
            InventoryItem data = ScriptableObject.CreateInstance<InventoryItem>();
            data = myInv.playerInv[i];

            //save the data in the file
            formatter.Serialize(file, data);

            //close dataStream
            file.Close();
        }
    }

    public void Load()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            //create binary formater
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}.inv", i), FileMode.Open);
            myInv.playerInv[i] = formatter.Deserialize(file) as InventoryItem;
            file.Close();
            i++;
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Reset() //delete saves for debuging
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath + string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath + string.Format("/{0}.inv", i));
            i++;
        }
    }
    //------------------------------------------------------------------------------
    /*private void OnEnable()
    {
        myInv.playerInv.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }


    


    public void SaveScriptables()
    {
        Reset(); //delete old save 
        for (int i = 0; i < myInv.playerInv.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}.inv", i)); //saves as {I}.inv
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
    }*/

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
