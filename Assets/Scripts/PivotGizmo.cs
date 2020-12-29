using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotGizmo : MonoBehaviour
{
    public float gizmoSize = 0.25f;
    public Color gizmoColor = Color.yellow;
    public float speed = 0.5f;
    public float rotationLimitR = 45f;
    public float rotationLimitL = -45f;

    Vector3 leftLimit;
    Vector3 RightLimit;


    void Start()
    {
        //Get current position then add 90 to its Y axis
        leftLimit = transform.eulerAngles + new Vector3(0f, rotationLimitR, 0f);

        //Get current position then substract -90 to its Y axis
        RightLimit = transform.eulerAngles + new Vector3(0f, rotationLimitL, 0f);
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.eulerAngles = Vector3.Lerp(leftLimit, RightLimit, time);
    }
}
