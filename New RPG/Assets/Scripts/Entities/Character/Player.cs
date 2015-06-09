using UnityEngine;
using System.Collections;

public class Player : Entity{

	private int exp = 0;

	AbstractMeleeWeapon equippedMeleeWeapon;
	float attackTimer;
	float timeToReAttack;
	bool isAttacking = false;
	Animator animator;

	void Start(){
		curHealth = maxHealth = 10;
		attackLevel = 3;
		strengthLvl = 3;
		defenseLvl = 3;
		agilityLvl = 1;
		equippedMeleeWeapon = null;
		timeToReAttack = .1f;
		animator = GetComponent<Animator> ();
	}

	void Update(){

		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		else
			if(isAttacking){
				isAttacking = false;
				animator.SetBool ("isAttacking", false);
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			if(attackTimer <= 0){
				isAttacking = true;
				attack ();
				attackTimer = timeToReAttack;
			}
		} 
	}

	public AbstractMeleeWeapon equipMeleeWeapon(AbstractMeleeWeapon weapon){
		AbstractMeleeWeapon oldWeapon = equippedMeleeWeapon;
		equippedMeleeWeapon = weapon;
		timeToReAttack = weapon.getRange ();

		return oldWeapon;
	}

	public AbstractMeleeWeapon unequipMeleeWeapon(){
		AbstractMeleeWeapon oldWeapon = equippedMeleeWeapon;	
		equippedMeleeWeapon = null;
		attackTimer = 1.0f;
		return oldWeapon;
	}


	private void attack(){
		Debug.Log("attack");
		animator.SetBool ("isAttacking", true);
		switch (GetComponent<Movement>().getDirectionFacing()) {
			case "up":
				animator.SetInteger ("directionFacing", 2);
			break;
				case "down":
			animator.SetInteger ("directionFacing", 0);
			break;
			case "left":
				animator.SetInteger ("directionFacing", 1);
			break;
			case "right":
				animator.SetInteger ("directionFacing", 3);
			break;
		}
	}
	protected override void die(){
		transform.position = new Vector3 (0,0,0);
		Debug.Log ("You have died :(");
	}




}
