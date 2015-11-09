using UnityEngine;
using System.Collections;

public class PersonMovement : MonoBehaviour {
	private Rigidbody person;
	public GameObject PersonGameObject;
	private bool hit = true;
	private Vector3 velocity;

	void Start(){
		person = PersonGameObject.GetComponent<Rigidbody> ();
		Random.Range(-10.0F, 10.0F), 0, Random.Range(-10.0F, 10.0F);
	}
	
	void Update () {
		
		if (hit) 
			person.position += new Vector3 (0.1f, 0.0f, 0.0f);
			person.position += new Vector3();

		else 
			person.position += new Vector3(-0.1f, 0.0f, 0.0f);		
		
	//	if (PersonGameObject.name != "Robot") {
			PersonGameObject.GetComponent<Animator> ().speed = 0.77f;
			PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
	//	}


	}
	
	void OnTriggerEnter(Collider col){
		if (col.tag == "wall"){
		//	print("Collision with wall!");
			person.rotation =  Quaternion.Inverse(person.rotation);
			if (hit)
				hit = false;
			else
				hit = true;
		}
	}
}