using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEye : Enemy {

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

        if (attackable)
        {
           
            StartCoroutine(Shoot(new Vector2(0,1f)));
            StartCoroutine(Shoot(new Vector2(0, -1f)));
            StartCoroutine(Shoot(new Vector2(-1f, 1f)));
            StartCoroutine(Shoot(new Vector2(-1f, -1f)));
            StartCoroutine(Shoot(new Vector2(-1, 0f)));
            StartCoroutine(Shoot(new Vector2(1, 0)));
            StartCoroutine(Shoot(new Vector2(1f, 1f)));
            StartCoroutine(Shoot(new Vector2(1f, -1f)));

        }



    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.MyInstance.TakeDamage(damage);

        }

    }
}
