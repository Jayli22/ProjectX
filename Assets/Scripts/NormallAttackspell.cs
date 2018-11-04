using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormallAttackspell : Spell {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void FixedUpdate()
    {
        if (alive)
        {
            gameObject.transform.position = Player.MyInstance.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            alive = false;
        }
    }
}
