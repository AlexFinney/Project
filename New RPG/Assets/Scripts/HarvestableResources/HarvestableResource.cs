using UnityEngine;
using System.Collections;
using System;

public class HarvestableResource : MonoBehaviour {

	
	protected float respawnTimer = 0;
	protected float timeToRespawn = 0;
	public float harvestTimer = 0;
	public float timeToHarvest = 0;

	public bool harvested = false;
	public bool harvesting = false;
	public GameObject outputTransform;
	public Player player;

	protected bool playerInRange;

	public AudioClip audioClip;
	private bool clicked = false;

	public Texture2D cursorImage;
	public int cursorSizeX = 16;
	public int cursorSizeY = 16;

	bool showCursor = false;



	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
			player = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			if(hit.collider != null && hit.collider.transform == transform){
			
				if(Vector2.Distance(player.gameObject.transform.position, 
				                    transform.position) < 1.2){
					harvesting = true;
				}
			}
		}

		if(harvesting && harvestTimer > 0){
			harvestTimer -= Time.deltaTime;
		}

		if (harvesting && harvestTimer <= 0) {
			harvestTimer = 0;
			harvesting = false;
			harvested = true;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
			gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
			addToPlayersInventory();
			showCursor = false;
			Cursor.visible = true;
		}
		if (harvested) {
			respawnTimer += Time.deltaTime;
			if(respawnTimer >= timeToRespawn){
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
				gameObject.GetComponents<BoxCollider2D>()[0].enabled = true;
				gameObject.GetComponents<BoxCollider2D>()[1].enabled = true;
				respawnTimer = 0;
				harvestTimer = timeToHarvest;
				harvested = false;

			}
			
		}

	
	}

	public void playStrikeSound(){
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
	}


	protected void addToPlayersInventory(){
		GameObject itemAdded = Instantiate(outputTransform, new Vector3(-100, -100, -100), Quaternion.identity) as GameObject;
		player.addItemToInventory(itemAdded.GetComponent<AbstractItem>());

	}


	void OnMouseEnter(){
		if(!harvested){
			if (Vector2.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, transform.position) < 1.2) {
				showCursor = true;
			}
		}
	}

	
	void OnMouseExit(){
		showCursor = false;
		Cursor.visible = true;
	}

	void OnGUI(){
		if(showCursor){
			Cursor.visible = false;
			GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, 
		                      Event.current.mousePosition.y-cursorSizeY/2, 
		                      cursorSizeX, cursorSizeY), 
		                 		cursorImage);
		}
	}


	
}
