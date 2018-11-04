using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public abstract class Character : MonoBehaviour {

    [SerializeField]
    protected float speed;

    private Rigidbody2D myRigidbody;

  //  [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int mp;
    [SerializeField]
    protected int maxMp;

    protected Coroutine attackRoutine;

    protected Vector2 direction;


    protected bool die;

    protected Vector3 min, max;

    // Use this for initialization

    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        die = false;
        //Debug.Log(gameObject.GetComponent<SpriteRenderer>().material.color.a);
        timeCount = 0;
    }

    float DURATION = 2.5f;
    float timeCount ;

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

    protected virtual void FixedUpdate()
    {
        if(die)
        {
            Color newColor = gameObject.GetComponent<SpriteRenderer>().material.color;
            timeCount += Time.deltaTime ;
            //float proportion = Time.time / DURATION;
       
            newColor.a -= timeCount / 15; 
            gameObject.GetComponent<SpriteRenderer>().material.color = newColor;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (timeCount > DURATION)
            {
                Destroy(gameObject);
            }
            
        }
    
            Move();

    }
    public void Move()
    {
        if (!die)
        {
            myRigidbody.velocity = direction * speed;
        }
        else
        {
            myRigidbody.velocity = direction * 0;
        }


    }

    public virtual void TakeDamage(int damage)
    {
        //health reduce 
        hp -= damage;
        if(hp<=0)
        {
            die = true;
                     
        }
    }

    public void Setlimits(Vector3 min, Vector3 max)
    {
        this.min = min;
        this.max = max;
    }

}
