using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    private bool flag;

    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
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

            MoneyCounter.setMoneyCounter(Random.Range(5, 50));

            while (!flag)
            {
                RaycastHit hit;
                Physics.SphereCast(new Vector3(Random.Range(5, 95), 40.0f, Random.Range(5, 95)), 0.06354f / 2.0f, Vector3.down, out hit);
                Vector3 position = hit.point;
                if (hit.point.y <= 10.0f & hit.point.y > 9.9f)
                {
                    Instantiate(gameObject.transform.parent.gameObject, position, Quaternion.identity);
                    Destroy(gameObject.transform.parent.gameObject);
                    flag = true;
                }
            }
        }
    }  
}
