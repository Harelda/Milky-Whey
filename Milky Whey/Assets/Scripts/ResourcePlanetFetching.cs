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
	public Canvas upgradeMenuCanvas;

	public int baseMineralGenRate;
	public int baseGasGenRate;
	public int basePowerGenRate;

	public int currentLevel = 1;

	public int upgradeCost;

	private LayerMask onlyShieldAndResourcePlanet;
	private List<GameObject> planets;

	// Use this for initialization
	void Start () {
		onlyShieldAndResourcePlanet = 1 << LayerMask.NameToLayer ("Shield") | 1 << LayerMask.NameToLayer ("Resource Planet");
		planets = new List<GameObject> ();
		UpgradeSuccess ();
		upgradeMenuCanvas.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		GenerateAllResources ();

		//Resource Controller

		//Constantly raycasting to the resource planet;
		for (int i = 0; i < planets.Count; i++) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, planets[i].transform.position, Mathf.Infinity, onlyShieldAndResourcePlanet);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {

				// Add resource to resource manager.
				ResourcePlanet rp = planets [i].GetComponent<ResourcePlanet> ();
				if (rp != null && !rp.isShieldActivated) {
					// Play Beam animations.
					planets [i].GetComponent<StormBeam> ().FireWeapon (gameObject.transform.position, rp.gameObject.transform.position);

					Debug.DrawRay (transform.position, planets [i].transform.position, Color.green);
					ResourceManager.instance.AddCertainResource (rp.GetResourceType (), rp.GetResourceAmount ());
				} else {
					planets [i].GetComponent<StormBeam> ().DestroyMagicBeam();
				}
			}
			if (hit.collider != null && hit.collider.tag == "Shield") {
				planets [i].GetComponent<StormBeam> ().DestroyMagicBeam();
			}
		}
	}

	public void OpenUpgradeMenu()
	{
		upgradeMenuCanvas.gameObject.SetActive (true);
	}

	public void CloseUpgradeMenu()
	{
		upgradeMenuCanvas.gameObject.SetActive (false);
	}

	public void Upgrade()
	{
		if (ResourceManager.instance.CostResource (ResourceType.MINERAL, 1000)) {
			currentLevel++;
			UpgradeSuccess ();
		}
	}

	public void UpgradeSuccess()
	{
		for (int i = 0; i < resourcePlanets[currentLevel-1].resourcePlanet.Length; i++) {
			planets.Add (resourcePlanets [currentLevel - 1].resourcePlanet [i]);
			resourcePlanets [currentLevel - 1].resourcePlanet [i].GetComponent<ResourcePlanet> ().isDetected = true;
		}
	}

	public void GenerateAllResources()
	{
		ResourceManager.instance.AddCertainResource (ResourceType.MINERAL, baseMineralGenRate);
		ResourceManager.instance.AddCertainResource (ResourceType.GAS, baseGasGenRate);
		ResourceManager.instance.AddCertainResource (ResourceType.POWER, basePowerGenRate);
	}
}