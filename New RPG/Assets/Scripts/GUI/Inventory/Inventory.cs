using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public InventorySlot[,] slots = new InventorySlot[4, 7];
	bool showInventory = false;

	int invWidth;
	int invHeight;
	int invX;
	int invY;

	int itemWidth;
	int itemHeight;

	public Sprite baseItemSlotImage;

	public bool itemsUpdated = true;



	// Use this for initialization
	void Start () {
		invWidth = 286;
		invHeight = 518;
		invX = Screen.width - invWidth - 10;
		invY = 10;
		itemWidth = 64;
		itemHeight = 64;

		for (int y = 0; y < slots.GetLength(1); ++y) {
			for (int x = 0; x < slots.GetLength(0); ++x) {
				slots[x,y] = new InventorySlot(null);
			}	
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.I)) 
			showInventory = !showInventory;		
	
	}

	void OnGUI(){
		if (showInventory) {
				
			GUI.Box(new Rect(invX,invY,invWidth,invHeight), "Inventory:");

			for (int y = 0; y < slots.GetLength(1); ++y) {
				for (int x = 0; x < slots.GetLength(0); ++x) {
					Rect rect = new Rect(x*itemWidth + invX + x*5 + 7, invY + 25 + y * itemHeight + y*5, itemWidth, itemHeight);
					float val = rect.width;
					Texture2D texture = baseItemSlotImage.texture;
					GUI.DrawTexture(rect,texture);

					if(slots[x,y].getItemTexture() != null){
						Texture2D itemTexture = slots[x,y].getItemTexture();
						GUI.DrawTexture(rect, itemTexture);
					}				
				}	
			}
		}
	
	}


	public AbstractItem getItemAt(int index){
		return null;
	}

	public void addItem(AbstractItem item){
		bool added = false;
		for (int y = 0; y < slots.GetLength(1); ++y) {
			for (int x = 0; x < slots.GetLength(0); ++x) {
				if(slots[x,y].getItemTexture() == null){
					slots[x,y] = new InventorySlot(item);
					added = true;
					break;
				}				
			}	
			if(added)
				break;

		}
	}





}
