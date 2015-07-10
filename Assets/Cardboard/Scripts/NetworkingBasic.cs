using UnityEngine;
using System.Collections;


public class NetworkingBasic : MonoBehaviour {
	public string url = "http://192.168.51.150:8000/velocity.txt";
	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		print (www.text[0]);
		print (www.text[1]);
		print (www.text[2]);
	}
}