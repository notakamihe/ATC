using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour
{   
    public Rigidbody rb;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) <= 2 && (transform.position.z - player.position.z <= Random.Range(15,20) && transform.position.z >= player.position.z) )
        {
            rb.useGravity = true;
            
        }
    }

    void OnCollisionEnter (Collision collider)
    {
        if (collider.collider.name == "Ground")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
