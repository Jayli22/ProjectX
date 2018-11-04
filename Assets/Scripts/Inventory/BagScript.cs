using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {

    [SerializeField]
    private GameObject slotPrefab;
    private static BagScript instance;

    public List<SlotScript> slots = new List<SlotScript>();
    

    public static BagScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BagScript>();
            }
            return instance;
        }
    }

    private void Awake()
    {
    }
    public void AddSlots(int slotCount)
    {
        for(int i = 0; i < slotCount; i++)
        {
            SlotScript slot = Instantiate(slotPrefab, transform).GetComponent<SlotScript>();
            slot.slotnumber = i;
            slots.Add(slot);
        }
    }
    public void Update()
    {
        
    }

    public bool AddItem(Item item)
    {
        foreach(SlotScript slot in slots)
        {
            if(slot.IsEmpty)
            {
                slot.AddItem(item);
                return true;
            }
        }
        return false;

    }

  
}
