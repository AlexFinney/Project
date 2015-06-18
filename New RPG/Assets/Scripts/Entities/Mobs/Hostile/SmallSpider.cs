using UnityEngine;
using System.Collections;

public class SmallSpider : HostileMob {

	// Use this for initialization
	void Start () {
		attackLevel = 3;
		defenseLvl = 1;
		strengthLvl = 1;
		agilityLvl = 2;
		secondsToRegain1HP = 10;
		maxHealth = curHealth = 12;
		attackTimer = timeToReAttack = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void die ()
	{
		if (deadMob != null) {
			GameObject go = (GameObject)GameObject.Instantiate(deadMob, gameObject.transform.position, gameObject.transform.rotation);
		}
		Destroy (gameObject);
	}
}
