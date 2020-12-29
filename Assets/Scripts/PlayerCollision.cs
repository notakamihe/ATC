using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Transform player;
    public new FollowPlayer camera;
    public Vector3 initialCameraPos;
    public Quaternion initialCameraRot;
    public Vector3 initialOffset;
    public float timeStart = 5;
    public bool playerSprung = false;
    public bool playerSprungSetOnce = false;
    public bool firstTimeOnGround = true;
    public bool offsetSet = false;

    void Start () 
    {
        initialOffset = camera.offset;
        initialCameraPos = camera.transform.position;
        initialCameraRot = camera.transform.rotation;
    }


    void Update ()
    {
        if (playerSprung && playerSprungSetOnce == false)
        {
            camera.offset += new Vector3 (0, 3, 0);
            camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.x + 35, 0, 0);
            playerSprungSetOnce = true;
        }
    }

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Obstacle") {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        } else {
            if (collisionInfo.collider.tag == "Teleporter")
            {
                player.position += new Vector3(0, 0, collisionInfo.gameObject.GetComponent<Teleport>().teleportDistance);
            }

            if (collisionInfo.collider.tag == "Spring") {
                movement.rb.AddForce(0, collisionInfo.gameObject.GetComponent<SpringPlayer>().springForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                FindObjectOfType<AudioManager>().Play("PlayerSpring");
                playerSprung = true;

                if (firstTimeOnGround)
                {
                    firstTimeOnGround = false;
                }
            }

            if (collisionInfo.collider.tag == "Slower")
            {
                movement.forwardForce *= collisionInfo.gameObject.GetComponent<SlowerStats>().slowScale;
                Invoke("callResetSpeed", collisionInfo.gameObject.GetComponent<SlowerStats>().slowDuration);
            }

            if (collisionInfo.collider.name == "Ground") {
                Debug.Log("Ground!");
                movement.isOnGround = true;
                playerSprung = false;
                playerSprungSetOnce = false;
                camera.offset = initialOffset;
                camera.transform.rotation = initialCameraRot;
            }
        }
    }

    void callResetSpeed ()
    {   
        Debug.Log("Reset!");
        movement.resetSpeed();
    }

}
