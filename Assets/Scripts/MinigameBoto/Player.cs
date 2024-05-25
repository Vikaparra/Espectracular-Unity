using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    private float movementX;
    private Vector3 initialPosition;
    [SerializeField] private UnityEvent onFinishLine;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.initialPosition = this.transform.position;
    }

    void Update()
    {
        //  movementX = Input.acceleration.x * moveSpeed;       
        //  transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y); 
        movementX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * moveSpeed, 0f);
    }

    public void ResetPlayer(){
        this.transform.position = this.initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Finish") {
            this.onFinishLine.Invoke();
        }
    }
}
