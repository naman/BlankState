using UnityEngine;
using System.Collections;

public class SocialForce : MonoBehaviour {
	private Rigidbody[] people;
	private int A = 2000;
	private float B = 0.5f;
	private float M = 60.0f; //kg
	
	
	void Start(){
		people = GameObject.Find ("People").GetComponentsInChildren<Rigidbody>();
	}
	
	//Called after every 0.02 seconds
	void FixedUpdate(){
		foreach (Rigidbody i in people) {
			Vector3 Force = Vector3.zero;

			foreach (Rigidbody j in people) {
				Force += calculateSocialForce (i,j) ; //returns a Vector3 with Force in some units
			}
			i.position += i.velocity * Time.deltaTime;
			i.velocity += (Force) / M * Time.deltaTime;
		}
	}
	
	Vector3 calculateSocialForce(Rigidbody target, Rigidbody person){
		if (target.GetInstanceID () != person.GetInstanceID ()) {
			
			Vector3 dx = target.position - person.position; //Vector3 : distance b/w target and person
			
			//normalisation (in the direction of target)
			//Vector3 normal_vector = dx / dx.magnitude; //(1 or -1)
			 
			// OR

			Vector3 normal_vector = dx;
			normal_vector.Normalize();

			float exponent_term = (0.7f - dx.magnitude)/B;
			float Force_X = A* Mathf.Pow(2.718f,exponent_term)*normal_vector.z;
			float Force_Z = A* Mathf.Pow(2.718f,exponent_term)* normal_vector.z;
			Vector3 Force = new Vector3 (Force_X, 0.0f, Force_Z); 
			//Sum of all forces due to every person around. In this case, just on person, so sum not required
			return Force;
		} else {
			return Vector3.zero;
		}
	}
	}