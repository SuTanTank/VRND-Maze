using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoof;
    public GameObject door;
    public float floatingSpeed = 2f;
    public GameObject player;    
    void Start()
    {       
        
    }
    void Update()
	{
        //Not required, but for fun why not try adding a Key Floating Animation here :)        
        transform.SetPositionAndRotation(transform.position + new Vector3(0f, Mathf.Sin(Time.time * floatingSpeed) * 0.01f, 0f), Quaternion.Euler(-90f, Time.time * 100f, 0f));
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy        
        if (!player.GetComponent<PlayerScript>().hasKey)
        {
            Debug.Log("Key Collected!");
            door.GetComponent<Door>().Unlock();
            GameObject poof = Object.Instantiate(keyPoof, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Debug.Log(poof.name);
            poof.GetComponent<ParticleSystem>().Play();
            player.GetComponent<PlayerScript>().CollectKey();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            poof.GetComponent<DieAfterSeconds>().enabled = true;
        }
    }

}
