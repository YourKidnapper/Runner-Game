using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float interpVelocity;
    public Vector3 offset;
    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target)
        {
            Vector3 posNoZ = transform.position + Vector3.down;
            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * 10f;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos - offset, 0.25f);
        }
    }
}
