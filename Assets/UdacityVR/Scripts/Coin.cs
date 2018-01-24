using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{

    //Create a reference to the CoinPoofPrefab
    public GameObject poofPrefab;
    public float floatingSpeed = 2f;
    public GameObject playerObject;
    public AudioClip clip_click = null;

    private PlayerScript player;
    private AudioSource _audio_source;
    private void Awake()
    {
        player = playerObject.GetComponent<PlayerScript>();
        _audio_source = gameObject.GetComponent<AudioSource>();
        _audio_source.clip = clip_click;
        _audio_source.playOnAwake = false;        
    }

    void Update()
    {
        //Not required, but for fun why not try adding a Key Floating Animation here :)        
        transform.SetPositionAndRotation(transform.position + new Vector3(0f, Mathf.Sin(Time.time * floatingSpeed) * 0.01f, 0f), Quaternion.Euler(0f, Time.time * 100f, 0f));
    }

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
        Debug.Log("Coin Collected!");        
        GameObject poof = Object.Instantiate(poofPrefab, transform.position + new Vector3(0f, 0.1f, 0f), poofPrefab.transform.rotation);
        poof.GetComponent<ParticleSystem>().Play();
        _audio_source.Play();
        player.CollectCoin();
        //poof.GetComponent<DieAfterSeconds>().enabled = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 1f);
    }

}
