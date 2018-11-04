using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject {

    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int quality;

    [SerializeField]
    private int stackSize;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemIntroduction;

    [SerializeField]
    private string itemDetail;
    
    private SlotScript slot;

    public int MyQuality
    {
        get
        {
            return quality;
        }

        set
        {
            quality = value;
        }
    }
    //Property for accessing the icon
    public Sprite MyIcon
    {
        get
        {
            return icon;
        }
    }

    public string MyitemName
    {
        get
        {
            return itemName;
        }
    }
    public string MyitemDetail
    {
        get
        {
            return itemDetail;
        }
    }
    public string MyitemIntroduction
    {
        get
        {
            return itemIntroduction;
        }
    }
    public SlotScript MySlot
    {
        get
        {
            return slot;
        }

        set
        {
            slot = value;
        }
    }

   public void Remove()
    {
        if( MySlot != null)
        {
            MySlot.RemoveItem(this);
        }
    }
}
