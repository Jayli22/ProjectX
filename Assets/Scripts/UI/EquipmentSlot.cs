using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item equipment;

    GameObject obj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (equipment != null)
        {

            Vector2 position;

            obj = Instantiate(Resources.Load("ItemIntroduce")) as GameObject;
            Canvas canvas = FindObjectOfType<Canvas>();
            obj.GetComponent<IntroductionMenuScript>().MyItemName.text = equipment.MyitemName;
            obj.GetComponent<IntroductionMenuScript>().MyDetail.text = equipment.MyitemDetail;
            obj.GetComponent<IntroductionMenuScript>().MyIntroduction.text = equipment.MyitemIntroduction;
            // itemIntroduction.transform.SetParent(canvas.transform);

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
        if (equipment != null)
        {

            //itemIntroduction.GetComponent<IntroductionMenuScript>().Show();
            Destroy(obj);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
