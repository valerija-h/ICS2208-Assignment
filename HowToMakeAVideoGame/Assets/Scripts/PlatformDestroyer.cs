﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDestructionPoint;


	// Use this for initialization
	void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < platformDestructionPoint.transform.position.z) {
            //Destroy(gameObject); //Destroy whichever object this script is attached to.
            gameObject.SetActive(false); 
        }
	}
}