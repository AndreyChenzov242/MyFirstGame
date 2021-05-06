using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    [SerializeField] private Item item;

    [SerializeField] private AudioClip pickupSound;

    public override void Interact()
    {
        base.Interact();

        PickUp(); 
    }
    
    void PickUp()
    {
        if (pickupSound != null)
        {
            GameObject audioSourceObject = new GameObject();
            var audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = .5f;
            audioSource.volume = 1f;
            audioSource.clip = pickupSound;
            audioSource.Play();
            Destroy(audioSourceObject, pickupSound.length);
        }
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

}
