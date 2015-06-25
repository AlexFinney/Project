using UnityEngine;
using System.Collections;

public abstract class AbstractMeleeWeapon : AbstractItem {

	protected float range;
	protected float rotationSpeed;
	protected float attackSpeed;
	protected int damage;
	protected int strengthToWield;
	protected int attackToWield;
	protected int magicToWield;
	public float rotation;
	protected int direction;
	public bool shouldRotateToEnd = false;
	public bool shouldRotateToStart = false;
	protected SpriteRenderer renderer;
	protected PolygonCollider2D hitBox;
	protected ArrayList currentHittingMobs;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getRange(){
		return range;
	}
	public int getDamage(){
		return damage;
	}
	public int getStrengthToWield(){
		return strengthToWield;
	}
	public int getAttackToWield(){
		return attackToWield;
	}

	public float getSpeed(){
		return attackSpeed;
	}
	
	//0 = D, 2 = U, 1 = L, 3 = R
	public void setPositionAndRotation(int direction){
		this.direction = direction;
		shouldRotateToEnd = true;
		setRotationAndPosition ();
	}

	protected void setRotationAndPosition(){
		gameObject.transform.localPosition = new Vector3(.6f,.07f,0);
		switch (direction) {
			case 0:
				transform.RotateAround(GetComponentInParent<Player>().gameObject.transform.position, Vector3.forward,300);
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0,0,270));			
				rotation = -60;
			break;
			case 1:
				transform.RotateAround(GetComponentInParent<Player>().gameObject.transform.position, Vector3.forward,135);
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0,0,90));			
				rotation = 60;
			break;
			case 2:
				transform.RotateAround(GetComponentInParent<Player>().gameObject.transform.position, Vector3.forward,120);
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0,0,90));		
				renderer.sortingOrder = 4;
				rotation = -60;
				
			break;
			case 3:
				transform.RotateAround(GetComponentInParent<Player>().gameObject.transform.position, Vector3.forward, 30);
				transform.rotation = Quaternion.identity;
				rotation = -60;
			break;
		}
	}

	public void activate(){
		hitBox.enabled = true;
		renderer.enabled = true;
	}

	public void deactivate(){
		hitBox.enabled = false;
		renderer.enabled = false;
		shouldRotateToStart = false;
		shouldRotateToEnd = false;
		renderer.sortingOrder = 5;
	}






}
