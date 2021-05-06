using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;               
    public Transform interactionTransform;  

    private GameObject[] player;
    private GameObject text;
    private GameObject pickText;


    public virtual void Interact()
    {
    }

    private void Start()
    {
        pickText = GameObject.Find("TextPickup");
    }

    void Update()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        float distance = Vector3.Distance(player[0].gameObject.transform.position, interactionTransform.position);
        if (distance <= radius)
        {
            pickText.GetComponent<TextState>().TextPickupOn(gameObject);

            if (Input.GetKey(KeyCode.E))
            {
                pickText.GetComponent<TextState>().TextPickupOff(gameObject);
                Interact();
            }
        }
        else if (pickText.GetComponent<Text>().enabled) 
        {
            pickText.GetComponent<TextState>().TextPickupOff(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
