using UnityEngine;
using System.Collections;

public class ManMove1 : MonoBehaviour {

	public Rigidbody man;
	public Rigidbody man2;

	void Update () {
		CollisionDetection ();
		man.transform.position += new Vector3(0.01f,0.0f,0.0f);
	}

	void CollisionDetection(){
		int A = 2000;
		float B = 0.08f;
		float e = 2.71f; 
		float M = 80.0f;
		Vector3 dx = man.position - man2.position;
		float mag = dx.magnitude;
		
		Vector3 normal = dx/mag; //Normal Vector in the direction from man2 -> man1
		Vector3 F = M *A * Vector3.Scale(new Vector3(Mathf.Pow (e,(mag / B)),0.0f, 0.0f), normal); //this is wrong, I want to do something like this F = sigma(A * exp(dx/B) * normal) 
		// 						Sum of all forces due to every person around. In this case, just on person.
		print(F);
		man.AddForce (F);

		man2.AddForce (-1*F);
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("Person")){
			print ("Collision Detected!");
		}
	}
}
