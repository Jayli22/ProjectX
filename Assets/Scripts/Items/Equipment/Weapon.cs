using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Equipment/Weapon", order = 2)]
public class Weapon : Equipment, IUseable
{

    public void Use()
    {
        Player.MyInstance.ChangeWeapon(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
