using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttributePlus : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Text attributeNumber;
    [SerializeField]
    private Text attributeName;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Player.MyInstance.MyKP > 2 )
        {
            switch (attributeName.text)
            {
                case "STR":
                    Player.MyInstance.MySTR++;
                    Player.MyInstance.MyKP-=3;

                    break;
                case "CON":
                    Player.MyInstance.MyCON++;
                    Player.MyInstance.MyKP-=3;

                    break;
                case "DEX":
                    Player.MyInstance.MyDEX++;
                    Player.MyInstance.MyKP-=3;

                    break;
                case "INT":
                    Player.MyInstance.MyINT++;
                    Player.MyInstance.MyKP-=3;

                    break;
                case "LUK":
                    Player.MyInstance.MyLUK++;
                    Player.MyInstance.MyKP-=3;

                    break;

            }
        }
    }


}
