using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 4000;
    public float sidewaysForce = 500;
    public float jumpForce = 200; 
    public bool isOnGround;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d") ) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } 

        if ( Input.GetKey("a") ) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } 

        if ( Input.GetKey(KeyCode.W) && isOnGround) {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            isOnGround = false;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }

        if (rb.position.y <= -1) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void resetSpeed ()
    {
        forwardForce = 4000;
    }
}
