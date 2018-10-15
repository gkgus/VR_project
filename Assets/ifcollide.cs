using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script make the user move to anothrer  scene when collided with the yellow sphere
public class ifcollide : MonoBehaviour {
	public Transform Moveto;
	public Transform Final_scene;
	void OnTriggerEnter (Collider col)
	{
		if(col.tag == "TargetObject")
		{
			print ("Collide");
			transform.position = Moveto.position;

		}
		if (col.tag == "Cafe") {
			print ("Cafe Collide");
			transform.position = Final_scene.position;
		}
	}


}