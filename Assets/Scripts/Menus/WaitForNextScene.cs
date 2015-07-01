using UnityEngine;
using System.Collections;

public class WaitForNextScene : MonoBehaviour {

	public float WaitTime = 3.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitAndPrint(2.5F));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(WaitTime);
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
