using UnityEngine;
using System.Collections;

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
public class ManMove2 : MonoBehaviour {

	public Rigidbody another;
	public GameObject PersonGameObject;

		void Start(){
		//trya = GameObject<Animation> ();	
		another = GetComponent<Rigidbody> ();
	}

		void Update () {
		Vector3 position = new Vector3 (0.01f, 0.0f, 0.0f);;
		//trya.GetComponent<Animation>().Play("HumanoidWalk");
		PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
	another.position += position;
	
	}

	
	}
		
		
	
//}

