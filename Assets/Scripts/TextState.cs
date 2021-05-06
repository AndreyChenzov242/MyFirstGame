using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextState : MonoBehaviour
{

    private GameObject text;

    HashSet<GameObject> listGameObjects;

    private void Start()
    {
        listGameObjects = new HashSet<GameObject>();
        text = GameObject.Find("TextPickup");
    }

    public void TextPickupOn(GameObject other)
    {
        listGameObjects.Add(other);
        text.GetComponent<Text>().enabled = true;
    }

    public void TextPickupOff(GameObject other)
    {
        listGameObjects.Remove(other);
        if (listGameObjects.Count == 0)
        {            
            text.GetComponent<Text>().enabled = false;
        }
    }
}
