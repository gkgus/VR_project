using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeMyselfeye : MonoBehaviour {
	private HeadLook lookWalk;
	private Transform head;
	private Transform wheelchair;
	// Use this for initialization
	void Start () {
		lookWalk = GetComponent<HeadLook> ();
		head = Camera.main.transform;
		wheelchair = transform.Find ("wheelchair_2");
	}
	
	// Update is called once per frame
	void Update () {
		if (lookWalk.isWalking) {
			wheelchair.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, head.transform.eulerAngles.y, 0.0f));
		}
	}
}
