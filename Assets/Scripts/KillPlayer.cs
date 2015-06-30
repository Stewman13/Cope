using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if(col.rigidbody.tag == "Player"){
			Destroy(col.gameObject);
			Camera.main.SendMessage("PlayerDied");
		}
	}
}
