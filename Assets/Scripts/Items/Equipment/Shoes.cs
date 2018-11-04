using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Shoes", menuName = "Equipment/Shoes", order = 2)]

public class Shoes : Equipment, IUseable
{
    public void Use()
    {
        Player.MyInstance.ChangeShoes(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
