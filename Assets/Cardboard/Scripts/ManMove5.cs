using UnityEngine;
using System.Collections;

public class ManMove5 : MonoBehaviour {
	private Rigidbody[] people;
	private int A = 2000;
	private float B = 0.5f;
	private Vector3 e = new Vector3 (2.71f, 2.71f, 2.71f);
	private float M = 60.0f; //kg
	void Start(){
		people = GameObject.Find ("People").GetComponentsInChildren<Rigidbody>();
	}

	//Called after every 0.02 seconds
	void FixedUpdate(){
		//float delta_time = Time.deltaTime;
/*		foreach (Rigidbody p1 in people) {
			foreach (Rigidbody p2 in people) {
				Vector3 Force = Vector3.zero;
				//if (p1.GetInstanceID() != p2.GetInstanceID()) {
					Force = calculateSocialForce (p2, p1); //returns a Vector3 with Force in some units
					p1.AddForce (-Force * 0.00000001f / M);
					p2.AddForce (Force * 0.00000001f / M);
					print (Force * 0.00000001f / M);
				//}
			}
		}*/
	}
	Vector3 calculateSocialForce(Rigidbody target, Rigidbody person){
		Vector3 dx = target.position - person.position; //Vector3 : distance b/w target and person
		//normalisation (in the direction of target)
		Vector3 initial_nij  = dx/dx.magnitude;

		Vector3 rij = new Vector3(10f,10f,10f); //rij = ri+rj (sum of radii)

		float F_x = A * Mathf.Pow (e.x, ((rij.x - dx.x) / B)) * initial_nij.x;
		float F_z = A * Mathf.Pow (e.z, ((rij.z - dx.z) / B));
		Vector3 Force = new Vector3 (F_x, 0.0f, F_z);
		//Sum of all forces due to every person around. In this case, just on person, so sum not required
		return Force;
	}
}