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

	public void applyDamage(int weaponDamage, Entity attacker){

		int myAgilRoll = Random.Range(0, agilityLvl + 1);
		int attackerRoll = Random.Range (0, attacker.attackLevel + 1);

		if(attackerRoll * .5 >= myAgilRoll){
			int damage = (int)(weaponDamage + .5 * attacker.strengthLvl);
			damage -= Random.Range (0, defenseLvl + 1);
			curHealth -= damage;
			Debug.Log("Hit for " + damage + "! " + curHealth + " health left!");
			if(curHealth < 0){
				curHealth = 0;
				die();
			}
		}else{
			Debug.Log("Dodged! Attacker rolled a " + attackerRoll + ", I rolled a " + myAgilRoll);
		}


	}
}
