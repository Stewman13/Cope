using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public GameObject Player;
	public Transform camTransform;
	public BasicMovement _Mov;

	public bool Shaking;

	// How long the object should shake for.
	public float shake = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 CamPos;
	Vector3 PlayerPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void Update()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		if (Player != null){
			_Mov = Player.GetComponent<BasicMovement> ();
		}

		if (shake > 0)
		{
			camTransform.localPosition = PlayerPos + Random.insideUnitSphere * shakeAmount;
			
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			if(Player != null){
				PlayerPos = new Vector3(Player.transform.position.x,Player.transform.position.y,-10);
				camTransform.localPosition = PlayerPos;
			}
		}
	}
}