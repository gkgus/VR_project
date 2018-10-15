using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLook : MonoBehaviour {
	public float velocity = 0.7f;
	public bool isWalking;
	private CharacterController controller;
	private Clicker clicker = new Clicker();
	// Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController> ();
		isWalking = false;
	}
	// Update is called once per frame
	void Update () {
		
		if (clicker.clicked ()) {
			isWalking = !isWalking;
		}
		if (isWalking) {
			controller.SimpleMove (Camera.main.transform.forward * velocity);
		}

		//controller.SimpleMove (Camera.main.transform.forward * velocity);
	}
}
