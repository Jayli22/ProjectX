using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ring", menuName = "Equipment/Ring", order = 2)]
public class Ring : Equipment, IUseable {

    public void Use()
    {
        Player.MyInstance.ChangeRing(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
