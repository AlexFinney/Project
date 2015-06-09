using UnityEngine;
using System.Collections;

public class CopperGreatSword : AbstractMeleeWeapon {

	// Use this for initialization
	void Start () {
		attackToWield = 3;
		strengthToWield = 3;
		range = 3.0f;
		damage = 7;
		speed = 4.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
