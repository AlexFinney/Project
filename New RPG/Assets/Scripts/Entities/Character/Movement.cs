using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	float speed = 1f;
	int directionFacing;
	Rigidbody2D body;
	Animator animator;
	Vector2 movementVec;
	float timer, timeToJumpAgain = 3f;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.S)) {
			if (!Input.GetKey (KeyCode.W)){
				directionFacing = 0;
			}

		}else if (Input.GetKey (KeyCode.W)) {
			if (!Input.GetKey (KeyCode.S)) {
				directionFacing = 2;
			}
		}

		if (Input.GetKey (KeyCode.A)) {
			if (!Input.GetKey (KeyCode.D)) {
				directionFacing = 1;
			}

		}else if (Input.GetKey (KeyCode.D)) {
			if (!Input.GetKey (KeyCode.A)) {
				directionFacing = 3;
			}
		}

		timer += Time.deltaTime;
		movementVec = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(movementVec != Vector2.zero){
			animator.SetBool("isWalking", true);
			animator.SetFloat("input_x", movementVec.x);
			animator.SetFloat("input_y", movementVec.y);
		}else{
			animator.SetBool("isWalking", false);
		}


		body.MovePosition (body.position + movementVec * Time.deltaTime * speed);
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if(timer > timeToJumpAgain){
				timer = 0f;
				jump ();
			}
		}
	}

	void jump(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 diff = body.position - new Vector2(mousePos.x, mousePos.y);
		if (diff.x < 0) {
			if(diff.x > -.3f)
				diff.x = 0;
			else
				diff.x = 1f;
		} else if (diff.x > 0) {
			if(diff.x < .3f)
				diff.x = 0f;
			else
				diff.x = -1f;
		}
		if (diff.y < 0) {
			if(diff.y > -.3f)
				diff.y = 0;
			else
				diff.y = 1f;
		} else if (diff.y > 0) {
			if(diff.y < .3f)
				diff.y = 0f;
			else
				diff.y = -1f;
		}
		body.position =  (body.position + diff);	
	}
	
	public int getDirectionFacing(){
		return directionFacing;
	}
}
