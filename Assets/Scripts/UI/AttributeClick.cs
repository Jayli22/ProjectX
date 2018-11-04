using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttributeClick : MonoBehaviour,
   IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Player.MyInstance.TKP = Player.MyInstance.MyKP;
        Player.MyInstance.TCON = Player.MyInstance.MyCON;
        Player.MyInstance.TDEX = Player.MyInstance.MyDEX;
        Player.MyInstance.TINT = Player.MyInstance.MyINT;
        Player.MyInstance.TSTR = Player.MyInstance.MySTR;
        Player.MyInstance.TLUK = Player.MyInstance.MyLUK;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
