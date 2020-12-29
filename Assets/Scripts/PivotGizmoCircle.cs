using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotGizmoCircle : MonoBehaviour
{
    public float gizmoSize = 0.25f;
    public Color gizmoColor = Color.yellow;
    public float speed = 0.5f;


    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
