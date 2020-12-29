using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strech : MonoBehaviour
{
    public bool isStretching = true;
    public Transform player;
    public float sizeLimit = 15f;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.rotation.eulerAngles.y == 90)
        {
            if (Mathf.Abs(transform.position.x - player.position.x) < 1 && player.position.z - transform.position.z <= 20 && player.position.z - transform.position.z >= 0)
            {
                strech();
            }
        }
        else if (Mathf.Abs(transform.position.z - player.position.z) <= 2)
        {
            strech();
        }
    }

    void strech ()
    {
        if (transform.localScale.x >= sizeLimit)
        {
            isStretching = false;
        } 

        if (isStretching)
        {
            transform.localScale += new Vector3(speed, 0, 0);
        }
    }
}
