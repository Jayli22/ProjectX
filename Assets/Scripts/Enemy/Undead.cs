using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : Enemy {

    private bool attack2;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("setAttack2", 2, attackInterval);
        InvokeRepeating("setAttack", 0, 5);
    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (attackable)
        {

            StartCoroutine(Shoot(new Vector2(0, 1f)));
            StartCoroutine(Shoot(new Vector2(0, -1f)));
            StartCoroutine(Shoot(new Vector2(-1f, 1f)));
            StartCoroutine(Shoot(new Vector2(-1f, -1f)));
            StartCoroutine(Shoot(new Vector2(-1, 0f)));
            StartCoroutine(Shoot(new Vector2(1, 0)));
            StartCoroutine(Shoot(new Vector2(1f, 1f)));
            StartCoroutine(Shoot(new Vector2(1f, -1f)));
            StartCoroutine(Shoot(new Vector2(1, 0.25f)));
            StartCoroutine(Shoot(new Vector2(1, -0.25f)));
            StartCoroutine(Shoot(new Vector2(0.25f, 1f)));
            StartCoroutine(Shoot(new Vector2(-0.25f, 1f)));
            StartCoroutine(Shoot(new Vector2(-1, 0.25f)));
            StartCoroutine(Shoot(new Vector2(-1, -0.25f)));
            StartCoroutine(Shoot(new Vector2(0.25f, -1f)));
            StartCoroutine(Shoot(new Vector2(-0.25f, -1f)));
            StartCoroutine(Shoot());


        }



    }

    protected override IEnumerator Shoot(Vector2 direction)
    {
        attackable = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDamage = damage;

        spell.MyDirection = direction;
        yield return new WaitForSeconds(attackInterval);
        attackable = true;


    }

    protected override IEnumerator Shoot()
    {
        attack2 = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDirection = Player.MyInstance.transform.position - spell.transform.position;
        spell.MyDamage = damage;

        yield return new WaitForSeconds(0.5f);
        spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDirection = Player.MyInstance.transform.position - spell.transform.position;
        spell.MyDamage = damage;

    }

    private void setAttack()
    {
        attackable = true;
    }
    private void setAttack2()
    {
        attack2 = true;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.MyInstance.TakeDamage(damage);

        }

    }
}
