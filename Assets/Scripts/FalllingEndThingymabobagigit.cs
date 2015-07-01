using UnityEngine;
using System.Collections;

public class FalllingEndThingymabobagigit : MonoBehaviour {

	public GameObject Earthqauke;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			Earthqauke.rigidbody.isKinematic = false;
			Earthqauke.rigidbody.useGravity = true;
			Earthqauke.audio.Play();
		}
	}
}
