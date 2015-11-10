using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SocialForce : MonoBehaviour {
	private Rigidbody[] people;
	private Rigidbody[] walls;
	private Vector3[] goaldir;
	private int As = 2000;
	private int Aw = 2000;
	private float Bs = 0.08f;
	private float Bw = 0.08f;
	private float M = 70.0f; //kg
	private float speed = 1f; // m/s
	private float responseTime=0.1f; // ss
	private float wallDist_t=0.5f; // m

	void Start(){

		people = GameObject.Find ("People").GetComponentsInChildren<Rigidbody>();
		walls = GameObject.Find ("Walls").GetComponentsInChildren<Rigidbody> ();
		goaldir = new Vector3[people.Length];
		 

		foreach (Rigidbody i in people) {
			if (i.name != "VRPerson") {
				i.position = new Vector3 (Random.Range (-5f, 5f), 0f, Random.Range (-4f, 4f));
			
				int idx = System.Array.IndexOf (people, i);
				float theta;
				theta=Random.Range (-3.142f, 3.142f);
				goaldir[idx] = new Vector3 (Mathf.Cos(theta), 0f, Mathf.Sin(theta));
				//goaldir[idx]=new Vector3 (Random.Range (-20f, 20f), 0f, Random.Range (-20f, 20f));
			}

		}

	}
	

	//Called after every 0.02 seconds
	void FixedUpdate(){
		foreach (Rigidbody i in people) {

				Vector3 Force = Vector3.zero;

				foreach (Rigidbody j in people) {

					Force += calculateSocialForce (i, j); //returns a Vector3 with Force in some units
			

				}
				foreach (Rigidbody j in walls) {
					
					Force += calculateWallForce (i, j); //returns a Vector3 with Force in some units

				}


			int idx = System.Array.IndexOf (people, i);

			goaldir[idx]=updateGoalDir(i, goaldir[idx]);

			Force += M*(goaldir[idx]*speed-i.velocity)/responseTime;
			Force.y=0f;
				if (i.name != "VRPerson" ) {
					i.velocity += (Force) / M * Time.deltaTime;
					i.position += i.velocity * Time.deltaTime;
				}
		}
		//System.GC.Collect();
		//Resources.UnloadUnusedAssets();
	}
	Vector3 updateGoalDir(Rigidbody person, Vector3 goaldir_person){

		float min = 10000f;
		foreach(Rigidbody wall in walls){
			Vector3 tmp = wall.position - person.position;
			float dx = tmp.magnitude;

			if(dx<min)
				min=dx;
		}
		if (min <= wallDist_t) {
			float theta;
			theta = Random.Range (-3.142f, 3.142f);
			return new Vector3 (Mathf.Cos (theta), 0, Mathf.Sin (theta));
		} else {
			return goaldir_person;
		}
	}

	Vector3 calculateSocialForce(Rigidbody target, Rigidbody person){
		if (target.GetInstanceID () != person.GetInstanceID ()) {
			
			Vector3 dx = target.position - person.position; //Vector3 : distance b/w target and person

			Vector3 normal_vector = dx;
			normal_vector.Normalize();

			float exponent_term = (0.7f - dx.magnitude)/Bs;
			float Force_X = As* Mathf.Pow(2.718f,exponent_term)* normal_vector.x;
			float Force_Z = As* Mathf.Pow(2.718f,exponent_term)* normal_vector.z;
			Vector3 Force = new Vector3 (Force_X, 0.0f, Force_Z); 
			//Sum of all forces due to every person around. In this case, just on person, so sum not required
			return Force;
		} else {
			return Vector3.zero;
		}
	}
	Vector3 calculateWallForce(Rigidbody target, Rigidbody person){
		if (target.GetInstanceID () != person.GetInstanceID ()) {
			
			Vector3 dx = target.position - person.position; //Vector3 : distance b/w target and person
			
			Vector3 normal_vector = dx;
			normal_vector.Normalize();
			
			float exponent_term = (0.7f - dx.magnitude)/Bw;
			float Force_X = Aw* Mathf.Pow(2.718f,exponent_term)* normal_vector.x;
			float Force_Z = Aw* Mathf.Pow(2.718f,exponent_term)* normal_vector.z;
			Vector3 Force = new Vector3 (Force_X, 0.0f, Force_Z); 
			//Sum of all forces due to every person around. In this case, just on person, so sum not required
			return Force;
		} else {
			return Vector3.zero;
		}
	}


}