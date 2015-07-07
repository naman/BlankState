using UnityEngine;
using System.Collections;

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
public class ManMove2 : MonoBehaviour {

	public Rigidbody another;

		void Start(){

		another = GetComponent<Rigidbody> ();
	}

		void Update () {
		Vector3 position = new Vector3 (-0.01f, 0.0f, 0.0f);;
	
		another.position -= position;
	
	}

	
	}
		
		
	
//}

