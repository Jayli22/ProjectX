using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy {

    protected override void Start()
    {
        base.Start();
        InvokeRepeating("setAttack", 0, attackInterval);
    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (attackable)
        {

            StartCoroutine(Shoot());


        }



    }

    protected override IEnumerator Shoot()
    {
        attackable = false;
        EnemySpell spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDirection = Player.MyInstance.transform.position - spell.transform.position;
        spell.MyDamage = damage;

        yield return new WaitForSeconds(0.1f);
        spell = Instantiate(spellPrefab, transform.position, transform.rotation) as EnemySpell;
        spell.MyDirection = Player.MyInstance.transform.position - spell.transform.position;
        spell.MyDamage = damage;

    }

    private void setAttack()
    {
        attackable = true;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.MyInstance.TakeDamage(damage);

        }

    }
}
