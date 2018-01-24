using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public bool hasKey = false;
    public int score = 2000;
    public int nCoins = 0;
    public float startTime;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        score = 2000 - (int)Mathf.Round(10 * (Time.time - startTime)) + 1000 * nCoins;
	}
    public int getNCoins()
    {
        return nCoins;
    }
    public void CollectCoin()
    {
        nCoins++;
    }

    public void CollectKey()
    {
        hasKey = true;        
    }

    public void FinishGame()
    {
        
    }
}
