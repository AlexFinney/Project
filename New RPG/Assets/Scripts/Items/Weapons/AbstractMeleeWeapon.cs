using UnityEngine;
using System.Collections;

public abstract class AbstractMeleeWeapon : AbstractItem {

	protected float range;
	protected float speed;
	protected int damage;
	protected int strengthToWield;
	protected int attackToWield;
	protected int magicToWield;


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





}
