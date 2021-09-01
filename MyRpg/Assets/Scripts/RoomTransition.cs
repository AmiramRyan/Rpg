using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Vector2 camShift;
    public Vector3 playerShift;
    private CamMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CamMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPos += camShift;
            cam.maxPos += camShift;
            other.transform.position += playerShift;
        }
    }
}
