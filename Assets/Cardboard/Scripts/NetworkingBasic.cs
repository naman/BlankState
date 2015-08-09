using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class NetworkingBasic : MonoBehaviour {

public string url = "http://192.168.51.150:8000/velocity.txt";
	private Rigidbody VR;

	void Start() {
	//	StartCoroutine (Fetch ());
		VR = GameObject.Find("VRPerson").GetComponent<Rigidbody>();
	}
	/*
	void FixedUpdate () {
		VR.position += new Vector3 (-0.01f,0.0f,0.0055f);
	}
*/
	IEnumerator Fetch(){
		Vector3 last_value = Vector3.zero;
		while (true) {
			float s = Time.realtimeSinceStartup;
				WWW www = new WWW (url);
			float e = Time.realtimeSinceStartup;

			yield return new WaitForSeconds (e-s+0.07f);
				string[] words = www.text.ToString ().Split (',');
				
				foreach(String x in words){
					print (x);
				} 
				float vx;
				float.TryParse (words [0], out vx);
				float vz;
			try{
				float.TryParse (words [1], out vz);
				Vector3 speed = new Vector3 (-vx, 0.0f, vz); //fixing the axes (-x and -z)
				
				if( speed != Vector3.zero)
					last_value = speed;
				if(speed==Vector3.zero){
					speed = last_value;
				}
				VR.position += speed;

			}catch(IndexOutOfRangeException){
				print("WTF");
			}
	
		}
	}

}