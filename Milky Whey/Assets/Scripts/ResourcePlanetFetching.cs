using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourcePlanetLevel
{
	public GameObject[] resourcePlanet;


	ResourcePlanetLevel(){}
}

public class ResourcePlanetFetching : MonoBehaviour {

	public ResourcePlanetLevel[] resourcePlanets;

	public int currentLevel = 1;

	private LayerMask onlyShieldAndResourcePlanet;


	// Use this for initialization
	void Start () {
		onlyShieldAndResourcePlanet = 1 << LayerMask.NameToLayer ("Shield") | 1 << LayerMask.NameToLayer ("Resource Planet");
	}
	
	// Update is called once per frame
	void Update () {

		//Resource Controller


		//Constantly raycasting to the resource planet;
		for (int i = 0; i < resourcePlanets[currentLevel-1].resourcePlanet.Length; i++) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, resourcePlanets[currentLevel-1].resourcePlanet[i].transform.position, Mathf.Infinity, onlyShieldAndResourcePlanet);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {

				// Add resource to resource manager.
				ResourcePlanet rp = resourcePlanets[currentLevel-1].resourcePlanet[i].GetComponent<ResourcePlanet>();
				if (rp != null && !rp.isShieldActivated) {
					Debug.DrawRay(transform.position, resourcePlanets[currentLevel-1].resourcePlanet[i].transform.position, Color.green);
					ResourceManager.instance.AddCertainResource (rp.GetResourceType (), rp.GetResourceAmount ());
				}
			}
		}
	}

	public void Test()
	{

		Debug.Log("Testing clicking");
	}
}