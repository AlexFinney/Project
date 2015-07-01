using UnityEngine;
using System.Collections;

public class CopperVein : HarvestableResource {
	
	void Start () {
		timeToHarvest = 5;
		timeToRespawn = 15;
		respawnTimer = 0;
		harvestTimer = timeToHarvest;
		harvesting = false;
	}


}
