using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class Overall : MonoBehaviour {
	public ThirdPersonCharacter[] people;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ThirdPersonCharacter[] people = GetComponentsInChildren<ThirdPersonCharacter> ();

		foreach (ThirdPersonCharacter i in people){
				print(i.transform.position);
		}
	}
}
}