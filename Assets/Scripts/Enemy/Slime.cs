using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy {


	// Use this for initialization
	protected override void Start () {
        base.Start();
        //min.x = transform.position.x - MoveRangeX;
        //min.y = transform.position.y - MoveRangeY;
        //max.x = transform.position.x + MoveRangeX;
        //max.y = transform.position.y + MoveRangeY;
        //gameObject.GetComponent<Enemy>().Setlimits(min, max);
        //attack.MyDirection = Vector2.up;
 
    }
    // Update is called once per frame
    protected override void FixedUpdate () {
        base.FixedUpdate();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), transform.position.z);
    }

    protected  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.MyInstance.TakeDamage(damage);

        }

    }


   // void onco
}
