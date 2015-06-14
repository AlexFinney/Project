using UnityEngine;
using System.Collections;

public class FloatingMessage : MonoBehaviour {

	public Color color;
	public float speed = .03f;
	public float duration = 3;
	public float alpha;
	public string message;
	public bool shouldStart = false;

	void Start () {
	
	}
	public void setMessage(string message){
		this.message = message;
	}

	public void setColor(Color color){
		this.color = color;
	}

	public void startFloating(){
		shouldStart = true;
	}

	void Update () {
		if(shouldStart){
			if (alpha>0){
				transform.position =  new Vector3(transform.position.x,
				                                   transform.position.y + speed*Time.deltaTime,
				                                   transform.position.z); 
				alpha -= Time.deltaTime/duration;
				GetComponent<TExt
			} else {
				Destroy(gameObject); // text vanished - destroy itself
			}
		}
	}
}
