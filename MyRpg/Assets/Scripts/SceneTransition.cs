using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneNameToLoad;
    public Vector2 newPlayerPos;
    public VectorValue oldPlayerPos;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            oldPlayerPos.initialValue = newPlayerPos;
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
