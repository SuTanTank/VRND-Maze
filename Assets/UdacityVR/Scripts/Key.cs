using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoof;
    public GameObject Door;
    public float floatingSpeed = 2f;
    public GameObject player;
    private Transform _transform;
    void Start()
    {
        keyPoof.GetComponent<ParticleSystem>().Stop();
        _transform = gameObject.transform;
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
        Debug.Log("Key Collected!");
        GameObject poof = Object.Instantiate(keyPoof, _transform);
        poof.GetComponent<ParticleSystem>().Play();
        player.GetComponent<PlayerScript>().CollectKey();
        Destroy(gameObject);
    }

}
