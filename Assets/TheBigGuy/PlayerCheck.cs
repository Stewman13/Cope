using UnityEngine;
using System.Collections;

public class PlayerCheck : MonoBehaviour {

	public GameObject BigGuy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player" && BigGuy.GetComponent<MoveTowards>().isWaiting == true){
			BigGuy.GetComponent<MoveTowards>().StopWaiting = true;
		}
		if(col.gameObject.tag == "Player" && BigGuy.GetComponent<MoveTowards>().isWaiting == false){
			Destroy(this.gameObject);
		}
	}
}
