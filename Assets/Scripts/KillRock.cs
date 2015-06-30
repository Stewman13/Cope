using UnityEngine;
using System.Collections;

public class KillRock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Ground"){
			GetComponent<FallingRock>().Spawned = false;
			Destroy(this.gameObject);
		}
	}
}
