using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

	public GameObject Rock;
	public GameObject spawn;

	public bool Spawned = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Player"){
			if(Spawned = false){
			Instantiate(Rock,spawn.transform.position,spawn.transform.rotation);
			Spawned = true;
			}
		}
	}
}
