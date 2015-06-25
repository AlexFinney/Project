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

	public AudioClip hurtSound;



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

		if(attackerRoll * 1.5 >= myAgilRoll){
			AudioSource.PlayClipAtPoint(hurtSound, gameObject.transform.position);
			int bonus = attacker.strengthLvl + 8;
			int maxDamage = Random.Range(1,bonus);
			int damage = Random.Range(0, weaponDamage) + (int)1.5 * attacker.strengthLvl;
			damage -= ((int) Random.Range (0, defenseLvl + 1) / 2);
			if(damage < 0)
				damage = 0;
			curHealth -= damage;
			GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>()
				.createNewMessage(gameObject, damage.ToString(), Color.red);
			if(curHealth <= 0){
				curHealth = 0;
				die();
			}
		}else{
			GameObject.FindGameObjectWithTag("MessageManager").GetComponent<MessageManager>()
				.createNewMessage(gameObject, "Dodged!", Color.black);
		}
	}

	public int getCurHealth(){
		return curHealth;
	}

	public int getMaxHealth(){
		return maxHealth;
	}


}
