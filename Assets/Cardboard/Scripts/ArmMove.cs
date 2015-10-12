using UnityEngine;
using System.Collections;

public class ArmMove : MonoBehaviour {

	public Vector3 eulerAngleVelocity;
	public Rigidbody leftHand; 
//	public Rigidbody rightHand;
//	public GameObject board;
	private GameObject fire;
	
	void Start(){ 
		leftHand  =  GetComponent<Rigidbody>();

//		rightHand = GetComponent<Rigidbody>();
		fire = GameObject.Find ("Board");	
//		board = GameObject.Find ("Board");
	}

	//public static float AngleDir(Vector2 A, Vector2 B){
	//	return -A.x * B.y + A.y * B.x;
	//}

	void FixedUpdate(){
//		if board is board left
//			left Handheld rotate
//		else right Handheld rotate
			
		//Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * -1);
		//	print (leftHand.rotation *  deltaRotation);
		leftHand.transform.LookAt (fire.transform);
		//if (AngleDir( robot, board)<0){
		//	leftHand.MoveRotation (leftHand.rotation * deltaRotation );
	//	}else{
		//leftHand.MoveRotation (leftHand.rotation * deltaRotation );
	//	}

	}

}
