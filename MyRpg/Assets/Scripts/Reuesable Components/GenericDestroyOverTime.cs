using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDestroyOverTime : MonoBehaviour
{
    [SerializeField]private float lifeTime;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}