using UnityEngine;
using System.Collections;

public class BasicHostileMobAI : MonoBehaviour {

	private Rigidbody2D target;
	private Rigidbody2D self;
	private Vector2 directionToTarget;
	private Vector2 directionToSpawn;
	public bool shouldMoveToSpawn = false;
	public bool hasSideAnimations;
	private Animator animator;

	public int aggroDistance = 2;
	public float attackDistance = .5f;
	
	private Vector2 spawnPoint;
	public float speed;
	
	// Use this for initialization
	void Start () {
		spawnPoint = GetComponent<Rigidbody2D> ().transform.position;
		self = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			float dist = Vector2.Distance(self.position, target.position);
			if(dist > .5f){
				animator.SetBool("moving",true);
				directionToTarget = (target.position - self.position).normalized;
				self.position = Vector2.Lerp(self.position, target.position, speed * Time.deltaTime);
			}else{
				animator.SetBool("moving",false);
			}

			Vector3 dir = target.transform.position - self.transform.position; 
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward); 

			if(!self.transform.rotation.Equals(q)){
				self.transform.rotation = Quaternion.Slerp(self.transform.rotation, q, Time.deltaTime*5f);
			}

		}else{
			if(shouldMoveToSpawn){
				animator.SetBool("moving",true);
				directionToSpawn = (spawnPoint - self.position).normalized;
				self.position = Vector2.Lerp(self.position, spawnPoint, Time.deltaTime * speed);

				float angle = Mathf.Atan2(directionToSpawn.y, directionToSpawn.x) * Mathf.Rad2Deg; 
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward); 
				self.transform.rotation = Quaternion.Slerp(self.transform.rotation, q, Time.deltaTime*5f);
			}
			if(Vector2.Distance(self.position, spawnPoint) < .3f) {
				shouldMoveToSpawn = false;
				animator.SetBool("moving",false);
			}
		}
	}


	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Player")) {
			target = other.attachedRigidbody;

		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Player")) {
			if(target.Equals(other.attachedRigidbody)){
				target = null;
				shouldMoveToSpawn = true;
			}
		}
	}
	// Use this for initialization

}
