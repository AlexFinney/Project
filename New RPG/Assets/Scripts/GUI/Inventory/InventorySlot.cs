using UnityEngine;
using System.Collections;

public class InventorySlot {
	
	AbstractItem slotItem;

	public InventorySlot(AbstractItem item){
		this.slotItem = item;
	}

	public Texture2D getItemTexture(){
		if(slotItem != null)
			return slotItem.getImage().texture;
		else
			return null;
	}

	public void setItem(AbstractItem item){
		this.slotItem = item;
	}

}
