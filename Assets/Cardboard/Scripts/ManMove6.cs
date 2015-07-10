using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class ManMove6 : MonoBehaviour {
	
		public ThirdPersonCharacter person;
		public ThirdPersonCharacter another;

		private int A;
		private float B;
		private int N;
		private int M;
		private Vector3 positions;
		private Vector3 velocities;
		private Vector3 e = new Vector3 (2.71f, 2.71f, 2.71f);



	void Start(){
			person = GetComponent<ThirdPersonCharacter>();
			another = GetComponent<ThirdPersonCharacter>();
		
			// Initialise system
			 A = 2000; //Newtons 
			 B = 0.08f; //50 cm (<5N for 8cm (modification by HMFV)
			 N = 20; //Number of Particles
			 M = 60; //kg
			 positions = new Vector3(Random.Range (1,10), Random.Range (1,10),Random.Range (1,10));
			 velocities = Vector3.zero;
	}
		
		Vector3 calculateSocialForce(ThirdPersonCharacter another, ThirdPersonCharacter person){
			Vector3 dx = another.transform.position - person.transform.position; //Vector3 : distance b/w target and person
			//normalisation (in the direction of target)
			Vector3 initial_nij  = dx/dx.magnitude;
			Vector3 rij = new Vector3(10f,10f,10f); //rij = ri+rj (sum of radii)
			float F_x = A * Mathf.Pow (e.x, ((rij.x - dx.x) / B)) * initial_nij.x;
			float F_z = A * Mathf.Pow (e.z, ((rij.z - dx.z) / B));
			Vector3 Force = new Vector3 (F_x, 0.0f, F_z);
			
			//Sum of all forces due to every person around. In this case, just on person, so sum not required
			return Force;
		}

		void TestEuler(){
			Vector3 Force = calculateSocialForce (another,person);
			positions += velocities*Time.deltaTime;
			velocities += Force / M * Time.deltaTime;
			another.Move(positions, false, false);
		} 

		void Update() {
				TestEuler ();
				

		}
}
}

