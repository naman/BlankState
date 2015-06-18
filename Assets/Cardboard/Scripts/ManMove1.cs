using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class ManMove1 : MonoBehaviour {
		public ThirdPersonCharacter character;

		void Start(){
			character = GetComponent<ThirdPersonCharacter>();
		}

		void Update () {
		//CollisionDetection ();
			Vector3 movement = new Vector3(0.0f,0.0f,-1.0f);
		//	if(character != null)
				//do your thing with that variable
				character.Move (movement, false, false);
		//		else
		//			Debug.LogError("variableName was null!");			
		}
	}
}

//	void CollisionDetection(){
//		int A = 2000;
//		float B = 0.08f;
//		float e = 2.71f; 
//		float M = 80.0f;
//		Vector3 dx = man.position - man2.position;
//		float mag = dx.magnitude;
//		Vector3 normal = dx/mag; //Normal Vector in the direction from man2 -> man1
//		Vector3 F = M *A * Vector3.Scale(new Vector3(Mathf.Pow (e,(mag / B)),0.0f, 0.0f), normal); //this is wrong, I want to do something like this F = sigma(A * exp(dx/B) * normal) 
		// 						Sum of all forces due to every person around. In this case, just on person.
//		print(F);
//		man.AddForce (F);

//		man2.AddForce (-1*F);
//	}

