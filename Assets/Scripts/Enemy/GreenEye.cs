using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEye : Enemy {

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
            StartCoroutine(Shoot(0f, 0.1f));
            StartCoroutine(Shoot(0, 0.3f));
            StartCoroutine(Shoot(0, 0.5f));
            StartCoroutine(Shoot(0, 0.7f));
            StartCoroutine(Shoot(0, 0.9f));
            StartCoroutine(Shoot(0, -0.1f));
            StartCoroutine(Shoot(0, -0.3f));
            StartCoroutine(Shoot(0, -0.5f));
            StartCoroutine(Shoot(0, -0.7f));
            StartCoroutine(Shoot(0, -0.9f));

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
