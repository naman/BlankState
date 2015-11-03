using UnityEngine;
using System.Collections;

public class RobotSpeech : MonoBehaviour {
	public AudioClip robo;
//	public int carwait = 1;
//	public Rigidbody Robot;
//	public Rigidbody vrperson;
	private float alpha = 0.0f;
	private bool startPlay;
	// Use this for initialization
	void Start () {
		startPlay = true;
//		vrperson = GetComponent<Rigidbody>();
//		Robot = GetComponent<Rigidbody>();
	//	InvokeRepeating ("PlaySound", 10f, 2f);
	//	StartCoroutine(SoundOut());
		StartCoroutine(PlaySomeSound(3.0F));
	}

	void Update () 
	{
	//	if(startPlay){
	//		StartCoroutine(PlaySomeSound(3.0F));
	//		startPlay = false;
	//	}
	}
	
	IEnumerator PlaySomeSound(float carWait)
	{
		while (true) {
			yield return new WaitForSeconds (carWait);
			alpha += 0.1f;
		//	print (alpha);
			AudioSource audio = GetComponent<AudioSource> ();			
			audio.clip = robo;
			audio.volume = alpha;
			audio.Play ();
		}
	}
}

