﻿using UnityEngine;
using System.Collections;

public class InstructionsOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Mouse0)){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
