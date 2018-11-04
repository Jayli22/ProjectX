using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Equipment/Armor", order = 1)]

public class Armor : Equipment, IUseable
{
    public void Use()
    {
        Player.MyInstance.ChangeArmor(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
