using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool playerIsDead = false;

	public GameObject Player;
	public GameObject ActiveCheckpoint;
	public GameObject Checkpoint1;
	public GameObject Checkpoint2;
	public GameObject Checkpoint3;

	// Use this for initialization
	void Start () {
		ActiveCheckpoint = Checkpoint1;
	}
	
	// Update is called once per frame
	void Update () {
		Died();
	}

	void Died(){
		if(playerIsDead == true){
			Instantiate(Player,ActiveCheckpoint.rigidbody.position,ActiveCheckpoint.rigidbody.rotation);
			playerIsDead = false;
		}
	}

	void PlayerDied(){
		playerIsDead = true;
	}
}
