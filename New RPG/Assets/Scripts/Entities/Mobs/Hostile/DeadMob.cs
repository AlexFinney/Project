using UnityEngine;
using System.Collections;

public class DeadMob : MonoBehaviour {

	private float timer = 15;
	public AudioClip squish;
	public AudioClip squeel;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (squish, transform.position);
		AudioSource.PlayClipAtPoint (squeel, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = 0;
			Destroy(gameObject);
		}

	}
}
