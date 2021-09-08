using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Vector2 direction;
    private float lifeTimeSec;
    public Rigidbody2D myRb;
    void Start()
    {
        //
        lifeTimeSec = lifeTime;
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeSec -= Time.deltaTime;
        if(lifeTimeSec <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Fire(Vector3 direction)
    {
        myRb.velocity = direction * speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Room"))
        {
            Destroy(this.gameObject);
        }
    }
}
