using UnityEngine;
using System.Collections;

public class Player : Entity{

	private int exp = 0;

	public AbstractMeleeWeapon equippedMeleeWeapon;
	float attackTimer;
	float timeToReAttack;
	bool isAttacking = false;
	Animator animator;
	MeleeAttack meleeAttack;

	void Start(){
		curHealth = maxHealth = 30;
		attackLevel = 3;
		strengthLvl = 3;
		defenseLvl = 3;
		agilityLvl = 1;
		timeToReAttack = .1f;
		animator = GetComponent<Animator> ();
		meleeAttack = GetComponentInChildren<MeleeAttack> ();
	}

	void Update(){

		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		else
			if(isAttacking){
				isAttacking = false;
				animator.SetBool ("isAttacking", false);
				if(equippedMeleeWeapon != null)
					equippedMeleeWeapon.deactivate();
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			if(attackTimer <= 0){
				if(equippedMeleeWeapon == null){
					attackTimer = 1.0f;
					isAttacking = true;
					meleeAttack.attack();
				}
				else{
					attackTimer = equippedMeleeWeapon.getSpeed();
					isAttacking = true;
					meleeAttack.attack();
					equippedMeleeWeapon.setPositionAndRotation(GetComponent<Movement>().getDirectionFacing());
					equippedMeleeWeapon.activate();

				}
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

	public AbstractMeleeWeapon getEquippedMeleeWeapon(){
		return equippedMeleeWeapon;
	}

	protected override void die(){
		transform.position = new Vector3 (0,0,0);
		Debug.Log ("You have died :(");
	}




}
