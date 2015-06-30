using UnityEngine;
using System.Collections;

public class Checkpoint1 : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player"){
			Camera.main.GetComponent<GameController>().ActiveCheckpoint = Camera.main.GetComponent<GameController>().Checkpoint2;
			player.GetComponent<BasicMovement>().isAngry = true;
		}
	}
}
