using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 36;
    
    public Dictionary<Item, int> items = new Dictionary<Item, int>();
    
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items.Add(item, 1);    
            }
            
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }
    
    public void Remove(Item item)
    {
        items.Remove(item); 

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
