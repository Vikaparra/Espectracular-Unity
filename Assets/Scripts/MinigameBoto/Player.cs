using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float movementX;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     movementX = Input.acceleration.x * moveSpeed;       
     transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y); 
    }

     void FixedUpdate() {
        rb.velocity = new Vector2 (movementX, 0f);
    }
}
