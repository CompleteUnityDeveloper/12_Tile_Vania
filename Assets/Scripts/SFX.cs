using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    [SerializeField] AudioClip coinPickupSound;
    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()
    {
        myAudioSource.PlayOneShot(coinPickupSound);
    }
}
