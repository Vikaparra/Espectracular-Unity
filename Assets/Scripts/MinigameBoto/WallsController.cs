using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
[SerializeField]
    private float speed;
    private bool isActive=true;
    private Vector3 initialPosition;

    private void Awake(){
        this.initialPosition = this.transform.position;
    }

    void FixedUpdate()
    {
        if (isActive){
            float movement = this.speed * Time.fixedDeltaTime;
            this.transform.position = this.transform.position + Vector3.down * movement;
        }
    }

    private void ToggleActive(bool isActive){
        this.isActive = isActive; 
    }

    private void OnCollisionEnter2D() {
        this.ToggleActive(false);
    }

    private void OnCollisionExit2D() {
        this.ToggleActive(true);
    }
}
