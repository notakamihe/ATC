using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("EndMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
