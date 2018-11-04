using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Shield", menuName = "Equipment/Shield", order = 2)]

public class Shield : Equipment, IUseable
{
    public void Use()
    {
        Player.MyInstance.ChangeShield(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
