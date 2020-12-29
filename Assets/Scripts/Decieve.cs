using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decieve : MonoBehaviour
{
    public bool isGrowing = true;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - player.position.x) <= 4 && Mathf.Abs(transform.position.z - player.position.z) <= 5 && Mathf.Abs(transform.position.y - player.position.y) <= 6)
        {
            grow();
        }
    }

    void grow () {
        if (transform.localScale.x >= 7f && transform.localScale.y >= 2f && transform.localScale.z >= 2f)
        {
            isGrowing = false;
        } 

        if (isGrowing)
        {
            transform.localScale += new Vector3(.2f, .1f, .1f);
        }
    }
}
