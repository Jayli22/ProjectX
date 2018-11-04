using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttributeMins : MonoBehaviour,IPointerClickHandler
{


    [SerializeField]
    private Text attributeNumber;

    [SerializeField]
    private Text attributeName;
    public void OnPointerClick(PointerEventData eventData)
    {
        
            switch (attributeName.text)
            {
                case "STR":
                if (Player.MyInstance.MySTR > Player.MyInstance.TSTR && Player.MyInstance.MyKP < Player.MyInstance.TKP)
                {
                    Player.MyInstance.MySTR--;
                    Player.MyInstance.MyKP+=3;
                }
                    break;
                case "CON":
                if (Player.MyInstance.MyCON > Player.MyInstance.TCON && Player.MyInstance.MyKP < Player.MyInstance.TKP)
                {
                    Player.MyInstance.MyCON--;
                    Player.MyInstance.MyKP += 3;
                }
                    break;
                case "DEX":
                if (Player.MyInstance.MyDEX > Player.MyInstance.TDEX && Player.MyInstance.MyKP < Player.MyInstance.TKP)
                {
                    Player.MyInstance.MyDEX--;
                    Player.MyInstance.MyKP += 3;
                }
                    break;
                case "INT":
                if (Player.MyInstance.MyINT > Player.MyInstance.TINT && Player.MyInstance.MyKP < Player.MyInstance.TKP)
                {
                    Player.MyInstance.MyINT--;
                    Player.MyInstance.MyKP += 3;
                }
                    break;
                case "LUK":
                if (Player.MyInstance.MyLUK > Player.MyInstance.TLUK && Player.MyInstance.MyKP < Player.MyInstance.TKP)
                {
                    Player.MyInstance.MyLUK--;
                    Player.MyInstance.MyKP += 3;
                }
                    break;

            }
        }
    

}
