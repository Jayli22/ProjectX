using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    private Transform target;
    [SerializeField]
    protected float attackInterval;
    [SerializeField]
    private int exp;
    protected bool attackable;

    [SerializeField]
    private List<itemDropList> itemRateList;

    [SerializeField]
    protected Spell spellPrefab;

    [SerializeField]
    protected int damage;

    private Dictionary<int, double> dropRateList;
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    protected int MyExp
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    protected override void Start()
    {
        base.Start();
        MoveAuto();
        target = Player.MyInstance.transform;
        attackable = true;

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Update()
    {
        FollowTarget();
        ChangeMoveAnimation();
    }

    protected void MoveAuto()
    {
        InvokeRepeating("ChangeDirection", 1, 2f);

 
    }
    protected void StopMoveAuto()
    {
      CancelInvoke("ChangeDirection");


    }

    private void ChangeDirection()
    {
        //产生随机数
        //System.Random r = new System.Random(System.Guid.NewGuid().GetHashCode());
       // int x = r.Next(-1, 1);
        //int y = r.Next(-1, 1);

        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);

        direction = Vector2.zero;
        if (y>0)
        {
            animator.SetBool("Move", true);
            direction += Vector2.up;
           // animator.SetFloat("DirectionY", 1);
        }
        if (y<0)
        {
            animator.SetBool("Move", true);
            direction += Vector2.down;
          //  animator.SetFloat("DirectionY", -1);
        }
        if (x<0)
        {
            animator.SetBool("Move", true);
            direction += Vector2.left;
         //   animator.SetFloat("DirectionX", -1);
        }
        if (x>0)
        {
            animator.SetBool("Move", true);
            direction += Vector2.right;
         //   animator.SetFloat("DirectionX", 1);
        }
        if(x==0 )
        {
          //  animator.SetFloat("DirectionX", 0);
        }
        if(y==0)
        {
           // animator.SetFloat("DirectionY", 0);
        }
        if (y == 0 &&x==0)
        {
         //   animator.SetBool("Move", false);
        }
       

    }

    private void ChangeMoveAnimation()
    {
        
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", direction.y);

    }

    private void FollowTarget()
    {
        //if (target != null)
      //  {
            direction = (target.transform.position - transform.position).normalized;
           // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
      //      StopMoveAuto();
      //  }
       // else if(!IsInvoking())
     //   {
       //     MoveAuto();
      //  }
    }

    public void ItemDropDecision(List<itemDropList> itemList)
    {
        double rate;
        for(int i = 0; i < itemList.Count; i++)
        {
            rate = Random.Range(0f, 1f);

            if(rate < itemList[i].dropRate)
            {
                BagScript.MyInstance.AddItem(itemList[i].item);
            }


        }

    }
    [System.Serializable]
    public class itemDropList
    {
        public Item item;
        public float dropRate;
    }
    

    public override void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            die = true;
            ItemDropDecision(itemRateList);
            Player.MyInstance.MyEXP = Player.MyInstance.MyEXP + exp;
        }
    }


    protected virtual IEnumerator Shoot(Vector2 direction)
    {
        attackable = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;

        spell.MyDirection = direction;
        spell.MyDamage = damage;
        yield return new WaitForSeconds(attackInterval);
        attackable = true;


    }
    protected virtual IEnumerator Shoot()
    {
        attackable = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDamage = damage;

        spell.MyDirection = Player.MyInstance.transform.position - spell.transform.position;
        yield return new WaitForSeconds(attackInterval);
        attackable = true;

    }
    protected virtual IEnumerator Shoot(float x,float y)
    {
        attackable = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        Vector2 tDirection;
        tDirection = Player.MyInstance.transform.position - spell.transform.position;
        tDirection.x += x;
        tDirection.y += y;
        spell.MyDirection = tDirection;
        spell.MyDamage = damage;

        yield return new WaitForSeconds(attackInterval);
        attackable = true;


    }

    protected IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

    }
}
