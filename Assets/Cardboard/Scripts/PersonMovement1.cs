using UnityEngine;
using System.Collections;

public class PersonMovement1 : MonoBehaviour {
	private Rigidbody person;
	public GameObject PersonGameObject;
	private bool hit = true;


	void Start(){
		person = PersonGameObject.GetComponent<Rigidbody> ();
	}
	
	void Update () {

		if (hit) 
			person.position += new Vector3 (-0.1f, 0.0f, 0.0f);
		 else 
			person.position += new Vector3(0.1f, 0.0f, 0.0f);		
		
		if (PersonGameObject.name != "Robot") {
			PersonGameObject.GetComponent<Animator> ().speed = 0.77f;
			PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
		}
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