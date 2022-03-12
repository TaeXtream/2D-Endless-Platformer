using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 7.0f;
    [SerializeField] float dashSpeed = 10.0f;

    CapsuleCollider2D myCapsuleCollider;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Jump using Keyboard Spacebar
    void OnJump(InputValue value)
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))) return;
        if (value.isPressed) rigidbody2D.velocity += new Vector2(0f, jumpSpeed * 2.0f); // Jump height boost
    }
    // Dash using Keyboard D
    void OnDash(InputValue value)
    {
        if (value.isPressed) rigidbody2D.velocity += new Vector2(dashSpeed, 0f); // Speed Boost
    }
    // Brake using Keyboard A
    void OnBrake(InputValue value)
    {
        if (value.isPressed) rigidbody2D.velocity -= new Vector2(rigidbody2D.velocity.x/2, 0f); // Slow down by half of current velocity
    }

    // OnTriggerEnter2D is build-in to detect collisions and specify what happens.
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemies" || other.tag == "Hazards" ) {
            DamageCheck();
        }
    }

    void DamageCheck() {
        Debug.Log("Ouch");
    }

}



// Code Storage

    // void DamageCheck(Collider2D other) {
    //     if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")) || myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Hazards"))) {
    //         Debug.Log("Ouch!");
    //     }
    // }
