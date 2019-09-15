using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    #region Singleton
    public static InventoryManager instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(instance);
    }
    #endregion


    public GameObject slotPanel;
    public List<Item> myItems = new List<Item>();
    private List<Slot> slots = new List<Slot>();


    void Start()
    {
        InitInvetory();

    }

    private void InitInvetory()
    {

        Slot[] tempSlots = slotPanel.GetComponentsInChildren<Slot>();
        int no = 1;
        foreach (Slot slot in tempSlots)
        {
            if (slot != null)
            {
                slot.inventoryNo = no++;
                slots.Add(slot);
            }
        }

        for (int i = 0; i < myItems.Count; i++)
        {
            slots[i].AddItem(myItems[i]);
        }
    }

    public bool AddItem(Item newItem)
    {
        bool isAdded = false;

        for (int i=0; i< slots.Count; i++)
        {
            if (slots[i].GetItem() == null)
            {
                slots[i].AddItem(newItem);
                isAdded = true;
                break;
            }
        }

        Debug.Log("isAdded : " + isAdded);
        return isAdded;
    }


}
