using UnityEngine;
using System.Collections;



public class randomiser : MonoBehaviour {
	private GameObject board;
	private GameObject fire;
	private Vector3 position_f;
	private Vector3 position_r;
	private Vector3 position_b;
	
	private Rigidbody mRobot;
	private Rigidbody mVR;
	public float speed = 0.001f;
//	private Rigidbody man1;
//	private Rigidbody man5;

	private GameObject robot;
	private bool hi;

	// Use this for initialization
	void Start () {
		fire = GameObject.Find ("Fire");	
		board = GameObject.Find ("Board");
		robot = GameObject.Find ("Robot");
		mRobot = robot.GetComponent<Rigidbody>();
		mVR = GameObject.Find ("VRPerson").GetComponent<Rigidbody>();

	//	man1 = GameObject.Find ("Man 1").GetComponent<Rigidbody>();
	//	man5 = GameObject.Find ("Man 5").GetComponent<Rigidbody>();

		position_f = new Vector3(Random.Range(-7.0f, 7f), 0.55f, Random.Range(-4f, 4f));
		position_b = new Vector3(Random.Range(-7.0f, 7f), 0.21f, Random.Range(-4f, 4f));
		position_r = new Vector3 (-8f,0.55f,Random.Range (-7.0f, 7f));
		mRobot.position = position_r;
		robot.GetComponent<RoboMove>().enabled = false;
		robot.GetComponent<RoboMove1>().enabled = false;
		hi = true;
		
//		robot.transform.LookAt(mVR.position);
	}

	// Update is called once per frame
	void Update () {	


		if (hi) {
			mRobot.position = Vector3.MoveTowards (mRobot.position, mVR.position, speed * Time.deltaTime);
//			

		} else {
			robot.GetComponent<RoboMove> ().enabled = true;
			mRobot.position = Vector3.MoveTowards (mRobot.position, board.transform.position, speed * Time.deltaTime * 0.6f);
		}

		//	print(Vector3.Distance (mRobot.position, mVR.position));
		if (Vector3.Distance (mVR.position, mRobot.position) < 1f) {
			hi = false;
		}
		if (Vector3.Distance (board.transform.position, mRobot.position) < 1f) {
		//	robot.GetComponent<RoboMove1> ().enabled = true;
		//	hi = true;
		}

	}



}
