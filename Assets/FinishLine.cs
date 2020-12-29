using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > transform.position.z)
        {
            FindObjectOfType<GameManager>().EndGameWin();
        }
    }
}
