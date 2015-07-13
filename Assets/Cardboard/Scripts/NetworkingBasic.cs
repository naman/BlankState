using UnityEngine;
using System.Collections;


public class NetworkingBasic : MonoBehaviour {
	public string url = "http://192.168.51.150:8000/velocity.txt";
	private Rigidbody VR;

	void Start() {
		StartCoroutine (Fetch ());
		VR = GameObject.Find("VR").GetComponent<Rigidbody>();
	}


	IEnumerator Fetch(){
		while (true) {
			//double s = Time.realtimeSinceStartup;
			WWW www = new WWW (url);
			yield return new WaitForSeconds(1);
			string[] words = www.text.ToString ().Split (',');
			float vx;
			float.TryParse (words [0], out vx);
			float vz;
			float.TryParse (words [0], out vz);
			Vector3 speed = new Vector3 (vx, 0.0f, vz);
			//print (speed);
			VR.position += speed;
			//double e = Time.realtimeSinceStartup;
			//print (e - s);
		}
	}
}