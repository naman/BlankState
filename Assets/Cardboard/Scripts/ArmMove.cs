using UnityEngine;
using System.Collections;

public class ArmMove : MonoBehaviour {

	public Vector3 eulerAngleVelocity;	
	public Rigidbody rightHand;
	public Rigidbody leftHand;

	private GameObject board;
	private GameObject fire;

	private Quaternion _lookRotation;
	private Vector3 _direction;
	private bool hit = false;
	public float speed = 1.0f;

	void Start(){ 
		leftHand  =  GetComponent<Rigidbody>();
		rightHand = GetComponent<Rigidbody>();	
		fire = GameObject.Find ("Fire");	
		board = GameObject.Find ("Board");
	}

	void FixedUpdate(){
		float step = speed * Time.deltaTime;
		_direction = (board.transform.position - leftHand.transform.position).normalized;
		_lookRotation = Quaternion.LookRotation (_direction, Vector3.forward);
		leftHand.transform.rotation = Quaternion.Slerp (leftHand.transform.rotation, _lookRotation, Time.deltaTime * speed);
	}
}