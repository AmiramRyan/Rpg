using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [Header("Who to follow")]
    public Transform target;

    [Header("Cam controls")]
    public float smoothOffset;

    public Vector2 maxPos; //set it up dynamicly based on the room size
    public Vector2 minPos; // down the devroad

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 tempTarget = new Vector3(target.position.x, target.position.y, transform.position.z);
            tempTarget.x = Mathf.Clamp(tempTarget.x, minPos.x, maxPos.x);
            tempTarget.y = Mathf.Clamp(tempTarget.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, tempTarget, smoothOffset);
        }
    }
}
