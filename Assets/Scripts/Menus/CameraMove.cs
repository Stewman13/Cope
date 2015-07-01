using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform Checkpoint1;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Checkpoint1.position, step);
	}
}
