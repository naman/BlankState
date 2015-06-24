using UnityEngine;
using System.Collections;

public class MoveVR : MonoBehaviour {

	public Rigidbody VR;
	// Use this for initialization
	void Start () {
		VR = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		VR.transform.position += new Vector3 (0.0f, 0.0f, 0.06f);
	}
}
