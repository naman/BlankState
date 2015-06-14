using UnityEngine;
using System.Collections;

public class ManMove4 : MonoBehaviour {

	public Rigidbody man;

	//public float speed;
	
	// Use this for initialization
	void Start () {
		man = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame

	void FixedUpdate () {
	//	CollisionForce ();	
		
		man.transform.position -= new Vector3(0.0f,0.0f,0.01f);
	}

}
