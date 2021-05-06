using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItemsPickup : Interactable
{
    public Item[] item;
    
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        foreach(Item it in item)
        {
            Debug.Log("Picking up " + it.name);
            bool wasPickedUp = Inventory.instance.Add(it);
            if (wasPickedUp)
            Destroy(gameObject);    
        }
    }
}
