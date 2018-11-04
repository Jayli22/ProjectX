using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Helmet", menuName = "Equipment/Helmet", order = 2)]
public class Helmet : Equipment, IUseable
{
    public void Use()
    {
        Player.MyInstance.ChangeHelmet(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
