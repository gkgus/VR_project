using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//In this script, the Wheelchair is rotated by users's sight
//Also, it controls the time limit shown by the traffic light and watch

public class WheelchairMove : MonoBehaviour {
	public Text lightTime;
	public Text lightTime2;
	public float timelimit = 30.0f; //time limited
	public float timelimit2 = 60.0f;
	private float afterfailtime; //change the value at the Start()
	private float afterfailtime2;
	private float scene1try; // change the value at the Start()
	public Transform FailMoveto;

	public RawImage Stopimg2;
	public RawImage Goimg2;
	public RawImage Stopimg;
	public RawImage Goimg;
	public Text Watch;
	public float starttime;
	public float scene2timereset;
	public GameObject obstacle;
	public GameObject scene1_info;
	public GameObject afterfail_info;
	//public GameObject position_info;
	public GameObject able_slope;
	public GameObject unable_slope;
	public GameObject s2_info;
	public GameObject afterfail_info_s2;
	public GameObject Moveto;
	public GameObject start_info;
	public GameObject restart_info;
	public GameObject restart_info_s2;

	//public GameObject cafe;
	Color nocolor = new Color32 (60, 63, 63, 225); // traffic off color
	Color stopcolor = new Color32(255,40,40,225); //stop light color- red
	Color gocolor = new Color32(15,190,0,225); // go light color -green
	private HeadLook lookWalk;
	private Transform head;
	private Transform body1;
	private int starttouch;

	//this is for sound
	private AudioSource carhorn; //sound for car horn;
	private AudioSource scene1snd; 
	private AudioSource scene2snd;
	private AudioSource finalsnd;
	//

	private Clicker touched = new Clicker(); //if touched, stop.
	void Start () {

		head = Camera.main.transform;
		body1 = transform.Find ("wheelchair_2");

		//Scene1
		Stopimg2.GetComponent<RawImage> ().color = nocolor;
		Goimg2.GetComponent<RawImage>().color = gocolor;
		Stopimg.GetComponent<RawImage> ().color = nocolor;
		Goimg.GetComponent<RawImage>().color = gocolor;
		lightTime.text = "0";
		lightTime2.text = "0";
		Watch.text = "Time"+"\n"+"12:59:" + "0";
		starttime = Time.time;
		afterfailtime = 10.0f;
		afterfailtime2 = 10.0f;
		scene2timereset = 0;
		scene1_info.SetActive (false);
		afterfail_info.SetActive (false);
		s2_info.SetActive (false);
		afterfail_info_s2.SetActive (false);
		able_slope.SetActive (false);
		restart_info.SetActive (false);
		restart_info_s2.SetActive (false);

		starttouch = 0; // start to touch 
		//this is for sound
		carhorn = GameObject.Find("jeep").GetComponent<AudioSource>(); // find audio sources
		scene1snd = scene1_info.GetComponent<AudioSource>();
		scene2snd = s2_info.GetComponent<AudioSource> ();
		finalsnd = GameObject.Find("final_msg").GetComponent<AudioSource> ();

		//
		lookWalk = GetComponent<HeadLook> (); 
	
	}

	// Update is called once per frame
	void Update () {
		if (starttouch == 0) {
			if (touched.clicked ()) {
				print ("You touched!");
				Destroy (start_info);
				starttime = Time.time;
				starttouch = 1;
			}
		}
		if(starttouch ==1)
		{
			body1.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, head.transform.eulerAngles.y, 0.0f));

			float gametime = Time.time - starttime;
		

		//This is playing on scene1
			if (transform.position.z < 26.38 && transform.position.z>-23) {
			float countdown = timelimit - gametime;
			if (gametime <= timelimit + afterfailtime) {	//timelimit, traffic light:green
				if (gametime <= timelimit) {
					Stopimg.color = nocolor;
					Stopimg2.color = nocolor;
					lightTime.text = "" + (int)countdown;
					lightTime2.text = "" + (int)countdown;
					Watch.text = "Time" + "\n" + "12:58:" + (int)(30 - countdown);
						if (afterfailtime != 0) {
							if (gametime < 9) {
								scene1_info.SetActive (true);
								if (!scene1snd.isPlaying) {
									scene1snd.Play ();
								}
							} else {
								scene1_info.SetActive (false);
								scene1snd.Stop ();
							}
						} else { // tell restart..
							if (gametime < 5) {
								restart_info.SetActive (true);
							} else {
								restart_info.SetActive (false);
							}
							
						}
					


				} else {									//after timelimit, traffic light: red
					Goimg.color = nocolor;
					Stopimg.color = stopcolor;
					Goimg2.color = nocolor;
					Stopimg2.color = stopcolor;
					lightTime.text = "STOP";
					lightTime2.text = "STOP";

					if (afterfailtime != 0) {
						afterfail_info.SetActive (true);
						lookWalk.isWalking = false;
						if (!carhorn.isPlaying) {
							carhorn.Play();
						}
								
					}

				}
			} else {										//after showing the message, game starts again
				carhorn.Stop();
				transform.position = FailMoveto.position;
				Goimg.color = gocolor;
				Stopimg.color = nocolor;
				Goimg2.color = gocolor;
				Stopimg.color = nocolor;
				Destroy (obstacle);
				afterfailtime = 0;
				Destroy (afterfail_info);
				starttime = Time.time;
			}

		}//scene1 don't touch!
		
		//This is scene2.....!!
		if (transform.position.z > 26.38) {
			
			//print ("You are in second scene");
			if (scene2timereset == 0) {
				starttime = Time.time;
			}
			scene2timereset = 1;

			//float countdown2 = timelimit - gametime;
			if (gametime <= timelimit2 + afterfailtime2) {
				if (gametime <= timelimit2) {
						Watch.text = "Time" + "\n" + "12:59:" + (int)(gametime);
						if (afterfailtime2 != 0) {
							if (gametime < 7) {
								s2_info.SetActive (true);
								if (!scene2snd.isPlaying) {
									scene2snd.Play ();
								}
							} else {
								s2_info.SetActive (false);
								scene2snd.Stop ();
							}
						} else {
							if (gametime < 5) {
								restart_info_s2.SetActive (true);
							} else {
								restart_info_s2.SetActive (false);
							}
						}
						
				} else {
					if (afterfailtime2 != 0) {
						lookWalk.isWalking = false;
						afterfail_info_s2.SetActive (true);
					}
				}
			} else {
				afterfail_info_s2.SetActive (false);
				starttime = Time.time;
				unable_slope.SetActive (false);
				able_slope.SetActive (true);
				transform.position = Moveto.transform.position;
				afterfailtime2 = 0;
			}




		}//scene2 don't tocuh!

			//Scene3
		if (transform.position.z < -23) {
				//print (scene2timereset);
				if (scene2timereset == 1) {
					starttime = Time.time;
					gametime = 0;
					scene2timereset = 0;

				}
				if (!finalsnd.isPlaying) {
					finalsnd.Play();
				}
				if (gametime > 18) {
					#if UNITY_EDITOR
						UnityEditor.EditorApplication.isPlaying = false;
					#else
						Application.Quit();
					#endif
				}

			}

		}//if touched..
	}
		

}