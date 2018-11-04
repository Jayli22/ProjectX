using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    protected Rigidbody2D myRigidBody;
    public AudioSource efxSource1;                   //Drag a reference to the audio source which will play the sound effects.

    [SerializeField]
    private float speed;
    [SerializeField]
    protected int damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private GameObject HitEffect;
    [SerializeField]
    private float castTime;

    private Transform target;

    protected bool alive;

    protected Vector2 direction;
    protected Vector2 startPosition;

    [SerializeField]
    private string myName;
public string MyName
    {
        get
        {
            return myName;
        }

        set
        {
            myName = value;
        }
    }

    public Vector2 MyDirection
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    public float CastTime
    {
        get
        {
            return castTime;
        }

        set
        {
            castTime = value;
        }
    }

    public int MyDamage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    // Use this for initialization
    protected virtual void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        startPosition = transform.position;
        alive = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    protected virtual void FixedUpdate()
    {
        //spell direction
        if (alive)
        {
            myRigidBody.velocity = direction.normalized * speed;

        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
            if(HitEffect!=null)
            Instantiate(HitEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            

        }
        if (Mathf.Sqrt((transform.position.x - startPosition.x) * (transform.position.x - startPosition.x) + (transform.position.y - startPosition.y)*(transform.position.y - startPosition.y)) > range)
        {
            alive = false;

        }

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag != "Player"  && collision.tag != "Spell")
        {
            alive = false;
        }

        if (collision.tag == "Enemy")
        {
          //  myRigidBody.velocity = Vector2.zero;
          //  alive = false;
            collision.GetComponent<Enemy>().TakeDamage(damage + Player.MyInstance.MySTR);
           // Destroy(gameObject);
        }

    }



}
