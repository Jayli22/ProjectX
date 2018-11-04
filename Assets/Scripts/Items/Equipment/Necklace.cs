using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Necklace", menuName = "Equipment/Necklace", order = 1)]
public class Necklace : Equipment, IUseable
{
    public void Use()
    {
        Player.MyInstance.ChangeNecklace(this);
        Remove();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
