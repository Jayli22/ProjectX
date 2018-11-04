using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }

    }
}
