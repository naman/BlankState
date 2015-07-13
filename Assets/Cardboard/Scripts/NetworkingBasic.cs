using UnityEngine;
using System.Collections;


public class NetworkingBasic : MonoBehaviour {
	public string url = "http://192.168.51.150:8000/velocity.txt";
	IEnumerator Start() {
		double s = Time.realtimeSinceStartup;
		WWW www = new WWW(url);
		yield return www;
		double e = Time.realtimeSinceStartup;
		print (e - s);

	}
}