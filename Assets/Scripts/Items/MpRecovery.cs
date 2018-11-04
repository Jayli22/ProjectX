using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MpRecovery", menuName = "Items/MpRecovery", order = 1)]
public class MpRecovery : Item, IUseable
{


    [SerializeField]
    private int mana;
    public void Use()
    {
        Remove();
        Player.MyInstance.MyMp += mana;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
