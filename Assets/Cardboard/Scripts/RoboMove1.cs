using UnityEngine;
using System.Collections;

public class RoboMove1 : MonoBehaviour {

	private Rigidbody robot; 
	private Rigidbody vr; 

	public float speed;
	//private GameObject board;
	//private GameObject fire;

	private Quaternion _lookRotation;
	private Vector3 _direction;
	public bool hit = true;

	void Start(){ 
		robot = GameObject.Find ("Robot").GetComponent<Rigidbody>();
		vr = GameObject.Find ("VRPerson").GetComponent<Rigidbody>();
//		fire = GameObject.Find ("Fire");	
//		board = GameObject.Find ("Board");
	}


	void FixedUpdate(){
		if (hit) {
			float step = speed * Time.deltaTime;
			_direction = (vr.position - robot.transform.position).normalized;
			_lookRotation = Quaternion.LookRotation (_direction);
			robot.transform.rotation = Quaternion.Slerp (robot.transform.rotation, _lookRotation, Time.deltaTime * speed);
		}
	}

}