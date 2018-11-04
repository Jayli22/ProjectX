using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour,IPointerClickHandler,IClickable,IPointerEnterHandler,IPointerExitHandler {

    private Stack<Item> items = new Stack<Item>();
    public int slotnumber;

    [SerializeField]
    private Image icon;
   // [SerializeField]
   // private GameObject itemIntroduction;
    public bool IsEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }

    public Item MyItem
    {
        get
        {
            if(!IsEmpty)
            {
                return items.Peek();
            }
            return null;
        }
    }

    public Image MyIcon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public int MyCount
    {
        get
        {
            return items.Count;
        }


    }

    public bool AddItem(Item item)
    {
        items.Push(item);
        icon.sprite = item.MyIcon;
        icon.color = Color.white;
        item.MySlot = this;
      

        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData.button == PointerEventData.InputButton.Left)
        {
            UseItem();
        }
    }


    public void UseItem()
    {
        if(MyItem is IUseable)
        {
            (MyItem as IUseable).Use();

        }
    }

    public void RemoveItem(Item item)
    {
        if(!IsEmpty)
        {
            items.Pop();
            GameManager.MyInstance.UpdateStackSize(this);
            Destroy(obj);
        }
    }

    public void Start()
    {
       // itemIntroduction = Instantiate(itemIntroduction);
    }
    

  


    GameObject obj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MyItem != null)
        {
            
            Vector2 position;

            obj = Instantiate( Resources.Load("ItemIntroduce")) as GameObject;
            Canvas canvas = FindObjectOfType<Canvas>();
            obj.GetComponent<IntroductionMenuScript>().MyItemName.text = MyItem.MyitemName;
            obj.GetComponent<IntroductionMenuScript>().MyDetail.text = MyItem.MyitemDetail;
            obj.GetComponent<IntroductionMenuScript>().MyIntroduction.text = MyItem.MyitemIntroduction;
            // itemIntroduction.transform.SetParent(canvas.transform);

            switch(MyItem.MyQuality)
            {
                case 1:
                    obj.GetComponent<IntroductionMenuScript>().MyItemName.color = Color.green;

                    break;
                case 2:
                    obj.GetComponent<IntroductionMenuScript>().MyItemName.color = new Color(174, 0, 184);

                    break;
                case 3:
                    obj.GetComponent<IntroductionMenuScript>().MyItemName.color = new Color(255,129,0);

                    break;
            }


            obj.transform.SetParent(canvas.transform);

           // Debug.Log(cornerall[3]/2);
           //  Debug.Log(cornersthis[3]);

            position.x = Input.mousePosition.x - 110;
            position.y = Input.mousePosition.y - 140;


            //itemIntroduction.transform.position = position;
            //itemIntroduction.GetComponent<IntroductionMenuScript>().Show();
            obj.transform.position = position;
            obj.GetComponent<IntroductionMenuScript>().Show();
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MyItem != null)
        {

            //itemIntroduction.GetComponent<IntroductionMenuScript>().Show();
            Destroy(obj);
        }
    }

  
}
