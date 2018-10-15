using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	public bool startgame;
	public GameObject startbutton;
	private float countdown = 3.0f;
	// Use this for initialization
	void Start () {
		startgame = false;
	}
	
	// Update is called once per frame
	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit) && (hit.collider.gameObject == startbutton)) {
			if (countdown > 0.0f) {
				countdown -= Time.deltaTime;
				startgame = true;
			}
		}
	}
}
