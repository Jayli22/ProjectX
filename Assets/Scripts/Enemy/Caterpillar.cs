﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : Enemy
{

    protected override void Start()
    {
        base.Start();


    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(attackable)
        StartCoroutine(Shoot());
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.MyInstance.TakeDamage(damage);

        }

    }
}