using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAtPlayer : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public bool isPinpointSet = false;
    public Vector3 pinpoint;
    public float detectionRange = 15;
    public bool chargePlayedOnce = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if (chargePlayedOnce == false && transform.position.z - player.position.z <= 40 && transform.position.z > player.position.z)
        {   
            if (FindObjectOfType<GameManager>().gameHasEnded == false)
            {
                 FindObjectOfType<AudioManager>().PlayOneShot("ChargeSound");
            }

           
            chargePlayedOnce = true;
        }

        if (transform.position.z - player.position.z <= detectionRange && transform.position.z > player.position.z && Mathf.Abs(transform.position.x - player.position.x) <= 5 && Mathf.Abs(transform.position.y - player.position.y) <= 2)
        {
            int randNum = Random.Range(0, 9);

            if (randNum <= 7 && isPinpointSet == false)
            {
                setPinpoint();
            }

            Debug.Log("Opp!");
            
            if (isPinpointSet)
            {
                charge();
            }
        }
    }

    void charge ()
    {
        transform.position = Vector3.MoveTowards(transform.position, pinpoint, 200 * Time.deltaTime);
        
    }

    void setPinpoint ()
    {
        pinpoint = player.position + new Vector3(0, 0.5f, 5);
        isPinpointSet = true;
    }
}
