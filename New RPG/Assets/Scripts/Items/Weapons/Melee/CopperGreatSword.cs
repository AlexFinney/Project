﻿using UnityEngine;
using System.Collections;

public class CopperGreatSword : AbstractMeleeWeapon {

	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		hitBox = GetComponent<PolygonCollider2D>();
		currentHittingMobs = new ArrayList ();

		attackToWield = 3;
		strengthToWield = 3;
		range = 3.0f;
		damage = 3;
		rotationSpeed = 1.3f;
		attackSpeed = .8f;
	}
	
	// Update is called once per frame
	void Update () {


		if (shouldRotateToEnd) {
			transform.RotateAround(GetComponentInParent<Player>().gameObject.transform.position, Vector3.forward, 
			                       rotation * Time.deltaTime * rotationSpeed);
		}

	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "HostileMob") {
			HostileMob mob = (HostileMob) other.GetComponent<Entity>();
			if(!currentHittingMobs.Contains(mob)){
				currentHittingMobs.Add(mob);
				other.GetComponent<Entity>().applyDamage(damage, GetComponentInParent<Player>());
				GetComponent<AudioSource>().Play();
			}
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "HostileMob") {
			currentHittingMobs.Remove((HostileMob) other.GetComponent<Entity>());
		}
	}


}
