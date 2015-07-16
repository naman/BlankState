using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {
	private Rigidbody person;
	public GameObject PersonGameObject;
	
	void Start(){
		person = PersonGameObject.GetComponent<Rigidbody> ();
	}
	
	void Update () {
		person.AddForce (person.transform.forward * 1000.0f);
		PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
	}
}