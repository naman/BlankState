using UnityEngine;

public class PersonMovement : MonoBehaviour {
	private Rigidbody person;
	public GameObject PersonGameObject;
	
	void Start(){
		person = PersonGameObject.GetComponent<Rigidbody> ();
	}
	
	void Update () {
		person.transform.LookAt (person.position + person.velocity); //look the right way
		PersonGameObject.GetComponent<Animator> ().speed = 2f * person.velocity.magnitude;
		PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
	}
}