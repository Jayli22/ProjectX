using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungBeetle : Enemy {


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
            StartCoroutine(Shoot(Vector2.up));
            StartCoroutine(Shoot(Vector2.down));
            StartCoroutine(Shoot(Vector2.left));
            StartCoroutine(Shoot(Vector2.right));
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
