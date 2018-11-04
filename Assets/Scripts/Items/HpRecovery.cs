using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HpRecovery", menuName = "Items/HpRecovery", order = 1)]
public class HpRecovery : Item,IUseable {



    [SerializeField]
    private int health;



    // Use this for initialization
   
    public void Use()
    {
        Remove();
        Player.MyInstance.MyHp += health;
    }
}
