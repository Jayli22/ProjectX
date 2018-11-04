using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : Spell {


    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Player" && collision.tag != "Spell")
        {
            alive = false;
        }

        if (collision.tag == "Enemy")
        {
            //  myRigidBody.velocity = Vector2.zero;
            //  alive = false;
            collision.GetComponent<Enemy>().TakeDamage(damage + Player.MyInstance.MyINT);
            Player.MyInstance.mhitAudio();

            // Destroy(gameObject);
        }

    }
}
