﻿using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel("game");
	}
}
