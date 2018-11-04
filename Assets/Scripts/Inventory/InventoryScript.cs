using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

    [SerializeField]
    private int slotsnumber;
    private static InventoryScript instance;
    private Bag bag;

    [SerializeField]
    private Item[] items;

    private CanvasGroup canvasGroup;
    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha > 0;
        }


    }
    public static InventoryScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }
    }


    // for debug
    

    private void Awake()
    {

        bag = (Bag)Instantiate(items[0]);
        bag.Initialize(slotsnumber);
        bag.Use();
        canvasGroup = GetComponent<CanvasGroup>();

    }


    // Use this for initialization
    void Start () {
		
	}
	
    public void AddItem(Item item)
    {
       // if(bag)
    }

	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    //HpRecovery hpRecovery = (HpRecovery)Instantiate(items[1]);
        //    Item obj = Resources.Load("Dagger") as Item;
        //    Item weapon = Instantiate(obj);
        //    bag.MyBagScript.AddItem(weapon);
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    //HpRecovery hpRecovery = (HpRecovery)Instantiate(items[1]);
        //    Item obj = Resources.Load("Serrated knife") as Item;
        //    Item weapon = Instantiate(obj);
        //    bag.MyBagScript.AddItem(weapon);
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Item hpRecovery = (HpRecovery)Instantiate(items[1]);
        //    bag.MyBagScript.AddItem(hpRecovery);
        //}
    }
    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;

    }
}
