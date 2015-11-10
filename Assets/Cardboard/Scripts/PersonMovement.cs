using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {
	private Rigidbody person;
	public GameObject PersonGameObject;

	void Start(){
		//Vector3 direction;
		//float theta;
		//theta=Random.Range (-3.142f, 3.142f);
		person = PersonGameObject.GetComponent<Rigidbody> ();
		//direction = new Vector3 (Mathf.Cos(theta), 0f, Mathf.Sin(theta));
		//speed = 1*Time.deltaTime; // m/second
		//person.velocity = direction * speed;
	}
	
	void Update () {

		// normalize so that fast or slow moving people retain average speed
		//person.velocity.Normalize ();
		//person.velocity = person.velocity / person.velocity.magnitude;
		//person.velocity = person.velocity * speed;

		//person.position += person.velocity;

		person.transform.LookAt (person.position + person.velocity); //look the right way
		PersonGameObject.GetComponent<Animator> ().speed = 3f * person.velocity.magnitude;
		PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
	
	}

	
}