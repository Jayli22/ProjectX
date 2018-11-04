using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStrom : Spell {

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Player" && collision.tag != "Spell" && collision.tag!="Enemy")
        {
            
            alive = false;
        }

        if (collision.tag == "Enemy")
        {
            //  myRigidBody.velocity = Vector2.zero;
            //  alive = false;
          StartCoroutine( TakeBack());
            collision.GetComponent<Enemy>().TakeDamage(damage + Player.MyInstance.MyINT);
            // Destroy(gameObject);
        }

    }

    IEnumerator TakeBack()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.3f);
        GetComponent<BoxCollider2D>().isTrigger = true;
       alive = false;


    }
}
