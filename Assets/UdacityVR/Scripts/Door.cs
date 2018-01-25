using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    private bool locked = true;
    // Create a boolean value called "opening" that can be checked in Update() 
    private bool opening = false;
    private bool doorsOpen = false;

    public AudioClip lockedSound;
    public AudioClip openSound;
    public float opentime = 2;
    private AudioSource audioSource;

    private float startOpenTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if (opening && (Time.time - startOpenTime >= opentime))
        {
            opening = false;
            doorsOpen = true;
            Camera.main.transform.parent.GetComponent<PlayerScript>().FinishGame();
        }            
        if (opening)
        {
            float rotateAngle = Mathf.LerpAngle(0, 90f, (Time.time - startOpenTime) / opentime);
            transform.Find("Door/Door_Main/Left_Door").transform.rotation = Quaternion.Euler(-90f, rotateAngle, 90f);
            transform.Find("Door/Door_Main/Right_Door").transform.rotation = Quaternion.Euler(-90f, - rotateAngle, -90f);
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        if (!locked || Camera.main.transform.parent.GetComponent<PlayerScript>().hasKey)
        {
            opening = true;
            startOpenTime = Time.time;
            audioSource.clip = openSound;
            audioSource.Play();
            GetComponentInChildren<BoxCollider>().enabled = false;
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
