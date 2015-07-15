using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class NetworkingBasic : MonoBehaviour {
	/*public Vector3 forceVec = new Vector3(50f,50f,50f);
	private Rigidbody rb;
	public Text text;
	
	void Start() {
		// Activate the gyroscope
		Input.gyro.enabled = true;
		text.text = "Start";
		rb = GameObject.Find("VR").GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		if (Input.gyro.enabled) {
			Vector3 force_x = Input.gyro.userAcceleration.x * forceVec;
			Vector3 force_y = Input.gyro.userAcceleration.y * forceVec;
			Vector3 force_z = Input.gyro.userAcceleration.z * forceVec;

			rb.AddForce (force_x);
			rb.AddForce (force_y);
			rb.AddForce (force_z);
			text.text = rb.position.ToString();
		
		} else {
			text.text = "Not working";
		}

	}

	*/


public string url = "http://192.168.51.150:8000/velocity.txt";
	private Rigidbody VR;

void Start() {
		StartCoroutine (Fetch ());
		VR = GameObject.Find("VR").GetComponent<Rigidbody>();
	}

	IEnumerator Fetch(){
		while (true) {
			float s = Time.realtimeSinceStartup;
			//try {
				WWW www = new WWW (url);
			float e = Time.realtimeSinceStartup;
			//print (e-s);
			yield return new WaitForSeconds (e-s+0.07f);
				string[] words = www.text.ToString ().Split (',');
				float vx;
				float.TryParse (words [0], out vx);
				float vz;
				float.TryParse (words [0], out vz);
				Vector3 speed = new Vector3 (-vx / 10, 0.0f, vz / 10); //fixing the axes (-x and -z)
				print (speed);
				VR.position += speed;
		//} catch (UnityException e) {
		//		print (e.Source);
		//	}
			//	double e = Time.realtimeSinceStartup;
				//print (e - s);

		}
	}

}