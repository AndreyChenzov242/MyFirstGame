using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent; 
    public GameObject inventoryUI;  

    Inventory inventory;

    InventorySlot[] slots; 

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                var item = inventory.items.ElementAt(i);
                slots[i].AddItem(item.Key, item.Value);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
