using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{   
    public Rigidbody rb;
    public float firstLimit;
    public float secondLimit;
    public float movementSpeed = 25;
    public bool isMovingPositive = true;
    public float movementRange1 = 2;
    public float movementRange2 = 2;
    public bool isVertical;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public float replayDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[0];
        audioSource2 = GetComponents<AudioSource>()[1];

        isVertical = (int) transform.rotation.eulerAngles.y == 90;

        if (isVertical)
        {
            setLimits(transform.position.z);
        } 
        else
        {
            setLimits(transform.position.x);
        }
    }

    // Update is called once per frame
    void Update()
    {  
        if (isVertical)
        {
            move(transform.position.z, 0, 0, movementSpeed * Time.deltaTime);

            if (Time.timeSinceLevelLoad % replayDelay > replayDelay - .1)
            {
                audioSource2.PlayOneShot(audioSource2.clip, .1f);
            }
        } 
        else
        {
            move(transform.position.x, movementSpeed * Time.deltaTime, 0, 0);

            if (Time.timeSinceLevelLoad % replayDelay > replayDelay - .1)
            {
                audioSource.PlayOneShot(audioSource.clip, .1f);
            }
        }
    }
    
    void setLimits (float dimension) {
        firstLimit = dimension - movementRange1;
        secondLimit = dimension + movementRange2;
    }

    void move (float dimension, float x, float y, float z) {
        if (isMovingPositive) 
        {
            rb.AddForce(x, y, z, ForceMode.VelocityChange);
        } else
        {
            rb.AddForce(-x, -y, -z, ForceMode.VelocityChange);
        }

        if (dimension <= firstLimit) 
        {
            isMovingPositive = true;
        } 
        
        if (dimension >= secondLimit)
        {
            isMovingPositive = false;
        }
    }

    void PlayWhoosh ()
    {
        audioSource.Play();
    }
}
