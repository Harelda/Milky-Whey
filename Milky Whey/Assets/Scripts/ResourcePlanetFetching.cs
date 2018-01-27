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



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Constantly raycasting to the resource planet;
		for (int i = 0; i < resourcePlanets[currentLevel-1].resourcePlanet.Length; i++) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, resourcePlanets[currentLevel-1].resourcePlanet[i].transform.position);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {
				// Fetch resources.
				Debug.Log ("Getting resources from " + resourcePlanets[currentLevel-1].resourcePlanet[i].GetComponent<ResourcePlanet>().planetName); 
				Debug.DrawRay(transform.position, resourcePlanets[currentLevel-1].resourcePlanet[i].transform.position, Color.green);


				// Add resource to resource manager.
				GameObject rp = resourcePlanets[currentLevel-1].resourcePlanet[i];
				ResourceManager.instance.AddCertainResource (rp.GetComponent<ResourcePlanet> ().GetResourceType (), rp.GetComponent<ResourcePlanet> ().GetResourceAmount ());
			}
		}
	}
}