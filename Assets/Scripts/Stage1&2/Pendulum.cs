﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    public float fixedX;
    public float speed;
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    void Update()
    {
        //transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.position = new Vector2(fixedX, transform.position.y + speed * Time.deltaTime);
        Push();
    }

    public void Push()
    {
        if(transform.rotation.z >0 
            && transform.rotation.z < rightPushRange
            && (body2d.angularVelocity >0)
            &&body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if(transform.rotation.z <0
            && transform.rotation.z >leftPushRange
            &&(body2d.angularVelocity <0)
            && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
