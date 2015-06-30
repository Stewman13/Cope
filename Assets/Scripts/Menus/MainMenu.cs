using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Play(){
		Application.LoadLevel(1);
	}

	void Quit(){
		Application.Quit();
	}
}
