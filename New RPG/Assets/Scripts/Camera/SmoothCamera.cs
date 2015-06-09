using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public Transform target;
	public float speed;
	public Camera camera;
	public float distance;

	float startTime;
	float journeyLength;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
		if (speed == 0)
				speed = 0.05f;

		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		camera.orthographicSize = (Screen.height / 100f) / 4f;
		//Debug.Log(Mathf.Abs((transform.position - target.position).magnitude));
		if (target && camera) {
			if((Mathf.Abs((transform.position - target.position).magnitude)) > distance)
				transform.position = Vector3.Lerp (transform.position, target.position, speed) + new Vector3 (0, 0, -1); 
				
		}
	}
}
