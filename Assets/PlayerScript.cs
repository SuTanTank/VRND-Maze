using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private int INITIAL_SCORE = 2000;
    public bool hasKey = false;
    public int score;
    public int nCoins = 0;
    public float startTime;
    public bool finished = false;
    public float usedTime = 0f;
    // Use this for initialization
    void Start () {        
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {        
        if (!finished)
        {
            usedTime = Time.time - startTime;
        }
        score = INITIAL_SCORE - (int)Mathf.Round(10 * usedTime) + 1000 * nCoins;
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
        finished = true;
    }
}
