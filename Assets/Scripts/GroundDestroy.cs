using UnityEngine;
using System.Collections;

public class GroundDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Trigger1"){
			Destroy(this.gameObject);
		}
	}
}
