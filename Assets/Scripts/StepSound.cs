using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    private AudioSource audioSourse;
    [SerializeField] AudioClip[] stepSound;

    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
    }
    
    void StepSoundPlay()
    {
        audioSourse.clip = stepSound[UnityEngine.Random.Range(0, stepSound.Length)];
        audioSourse.Play();
    }
}
