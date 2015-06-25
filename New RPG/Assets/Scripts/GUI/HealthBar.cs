using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	SpriteRenderer redBar;
	SpriteRenderer greenBar;
	Entity entity;
	Quaternion rotation;
	Vector3 initialPos;
	
	void Awake()
	{
		rotation = transform.rotation;
		initialPos = transform.localPosition;
	}

	// Use this for initialization
	void Start () {
		redBar = transform.Find ("RedHealthBar").GetComponent<SpriteRenderer>();
		greenBar = transform.Find ("GreenHealthBar").GetComponent<SpriteRenderer>();
		entity = GetComponentInParent<Entity> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (entity.getCurHealth () != entity.getMaxHealth ()) {
			showHealthBar();		
		}else{
			hideHealthBar();
		}

		float healthNormalized = (float) entity.getCurHealth () / (float) entity.getMaxHealth ();
		if(healthNormalized < 0)
			healthNormalized = 0;
		Vector3 oldScale = greenBar.transform.localScale;
		greenBar.gameObject.transform.localScale = new Vector3 (healthNormalized, 1,1);
	
	}

	void LateUpdate()
	{
		transform.rotation = rotation;
		Vector3 parentPos = gameObject.transform.parent.gameObject.transform.position;
		transform.position = new Vector3 (parentPos.x + initialPos.x, parentPos.y + initialPos.y, parentPos.z + initialPos.z);
	}

	public void showHealthBar(){
		redBar.enabled = true;
		greenBar.enabled = true;
	}

	public void hideHealthBar(){
		redBar.enabled = false;
		greenBar.enabled = false;
	}


}
