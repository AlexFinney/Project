using UnityEngine;
using System.Collections;

public class IronVein : HarvestableResource {
	
	void Start () {
		timeToHarvest = 7;
		timeToRespawn = 20;
		respawnTimer = 0;
		harvestTimer = timeToHarvest;
		harvesting = false;
	}
}
