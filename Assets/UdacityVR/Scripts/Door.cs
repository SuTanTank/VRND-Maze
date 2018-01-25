using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    private bool locked = true;
    // Create a boolean value called "opening" that can be checked in Update() 
    private bool opening = false;

    public AudioClip lockedSound;
    public AudioClip openSound;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        if (!locked)
        {
            opening = true;
            audioSource.clip = openSound;
            audioSource.Play();
            Destroy(gameObject, 1f);
        }
        else
        {
            audioSource.clip = lockedSound;
            audioSource.Play();
        }

    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
    }
}
