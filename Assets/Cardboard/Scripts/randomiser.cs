using UnityEngine;
using System.Collections;



public class randomiser : MonoBehaviour {
	private GameObject board;
	private GameObject fire;
	private Vector3 position;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		fire = GameObject.Find ("Fire");	
		board = GameObject.Find ("Board");

	//	position = new Vector3(Random.Range(-7.0f, 7f), 0.55f, Random.Range(-4f, 4f));
	//	print (position);
	//	Instantiate(fire, position, Quaternion.identity);
		
	//	Destroy (fire);
		
	//	pos = new Vector3(Random.Range(-7.0f, 7f), 0.21f, Random.Range(-4f, 4f));
	//	print (pos);
	//	Instantiate(board, pos, Quaternion.identity);	
	//	Destroy (board);

	}

	// Update is called once per frame
	void Update () {
			}
}
