using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : Spell {


    // Use this for initialization
    protected override void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
     //   direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //direction = Player.MyInstance.transform.position - transform.position;
        startPosition = transform.position;

        alive = true;

    }

    // Update is called once per frame
    protected override void FixedUpdate () {
        base.FixedUpdate();
	}

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Spell" && collision.tag != "Enemy")
        {
            //Debug.Log("123");
            alive = false;
        }

        //if (collision.tag == "Map")
        //{
        //    //Debug.Log("123");
        //    alive = false;
        //}


        if (collision.tag == "Player")
        {
            //  myRigidBody.velocity = Vector2.zero;
            //  alive = false;
            Player.MyInstance.TakeDamage(damage);
            // Destroy(gameObject);
        }
    }
}
