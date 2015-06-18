using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
	Player player;
	Animator animator;
	void Start () {
		player = GetComponentInParent<Player> ();
		animator = GetComponentInParent<Animator> ();
	}
	

	void Update () {
	
	}

	public void attack(){
		animator.SetBool ("isAttacking", true);

		animator.SetInteger ("directionFacing", GetComponentInParent<Movement>().getDirectionFacing());
	}
}
