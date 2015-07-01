using UnityEngine;
using System.Collections;

public class SwitchCheck3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "BigGuy"){
			col.GetComponent<MoveTowards>().CurrentCheckpoint = col.GetComponent<MoveTowards>().Checkpoint4;
		}
	}
}
