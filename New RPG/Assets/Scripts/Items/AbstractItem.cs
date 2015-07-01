using UnityEngine;
using System.Collections;

public abstract class AbstractItem : MonoBehaviour {
	
	bool canPickup = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Sprite getImage(){
		return GetComponent<SpriteRenderer> ().sprite;
	}

	public void setCanPickup(bool canPickup){
		this.canPickup = canPickup;
	}
}
