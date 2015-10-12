using UnityEngine;
using System.Collections;

public class RobotSpeech : MonoBehaviour {
	public AudioClip robo;
	public int carwait = 10;

	public Rigidbody Robot;
	public Rigidbody vrperson;

	private float alpha = 0.0f;

	// Use this for initialization
	void Start () {
		vrperson = GetComponent<Rigidbody>();
		Robot = GetComponent<Rigidbody>();

		//StartCoroutine(SoundOut());
	}


	void FixedUpdate(){
	//	print(Robot.transform.position - vrperson.transform.position);
		alpha +=0.1f*Time.deltaTime;
		AudioSource audio = GetComponent<AudioSource>();			
		audio.clip = robo;
		audio.volume = alpha;
	}

	IEnumerator SoundOut()
	{
		while (true){
		//	print(Vector3.Distance(Robot.position,vrperson.position));


			AudioSource audio = GetComponent<AudioSource>();			
			audio.clip = robo;
			audio.volume = alpha;

			Debug.Log("Speaking Robot!");
			yield return new WaitForSeconds(carwait);
			audio.Play();
		}
	}
}
