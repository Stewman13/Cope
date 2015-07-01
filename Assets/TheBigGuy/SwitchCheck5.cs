using UnityEngine;
using System.Collections;

public class SwitchCheck5 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "BigGuy"){
			col.GetComponent<MoveTowards>().CurrentCheckpoint = col.GetComponent<MoveTowards>().Checkpoint6;
		}
	}
}
