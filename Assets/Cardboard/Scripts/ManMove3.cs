using UnityEngine;
using System.Collections;

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
public class ManMove3 : MonoBehaviour {
	
	public Rigidbody another;
	public GameObject PersonGameObject;
	void Start(){
		
		another = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		Vector3 position = new Vector3 (0.0000000000001f, 0.0f, 0.0f);;
		PersonGameObject.GetComponent<Animator> ().Play ("HumanoidWalk");
		//another.position -= position;
		
	}
	
	
}



//}

