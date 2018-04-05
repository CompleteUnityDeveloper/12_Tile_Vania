using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    // Allows sound effects to be triggered seperate to the object they relate to. 
    // Useful if the gameObject is being destroyed.

    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] AudioClip playerDeathSound;
    // todo consider adding player SFX here too

    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()
    {
        myAudioSource.PlayOneShot(coinPickupSound);
    }

    public void PlayDeathSound()
    {
        myAudioSource.PlayOneShot(playerDeathSound);
    }

}
