using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
	
	protected int curHealth;
	protected int maxHealth;

	protected int attackLevel {get; set;}
	protected int strengthLvl {get; set;}
	protected int defenseLvl {get; set;}
	protected int agilityLvl {get; set;}
	protected int magicLvl  {get; set;}
	protected int secondsToRegain1HP = 5;



	void Start(){

	}

	void Update(){

	}
	
	public void damage(int val){
		curHealth -= val;
		if(curHealth >= 0)
			die();
	}

	public void incCurHealthBy(int val){
		curHealth += val;
	}	

	protected abstract void die();
}
