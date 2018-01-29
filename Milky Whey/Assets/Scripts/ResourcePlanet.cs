using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceType
{
	GAS=0,
	POWER,
	MINERAL,
	MAX
}

[System.Serializable]
public class Resource
{
	public ResourceType resourceType;
	public int resourceAmount;

}

public class ResourcePlanet : MonoBehaviour {

	public string planetName;
	public Resource resource;
	public int upgradeCost;
	public int repairCost;
	public GameObject tower;
	public GameObject shield;
	public GameObject destroyedTower;
	public bool isDetected = false;
	public bool isTowerActivated = false;
	public bool isShieldActivated = false;

	public Canvas upgradeMenuCanvas;

	private float timeCounter = 0.0f;
	private float shieldTimer = 2.0f;

	// Use this for initialization
	void Start () {
		upgradeMenuCanvas.gameObject.SetActive (false);
		tower.SetActive (false);
		destroyedTower.SetActive (false);
		shield.SetActive (false);
	}
		
	// Update is called once per frame
	void Update () {

		if (isShieldActivated) {
			timeCounter += Time.deltaTime;
			if (timeCounter > shieldTimer) {
				isShieldActivated = false;
				shield.SetActive (false);
				timeCounter = 0.0f;
			}
		}
	}

	public int SentOutResources()
	{
		// Resource planet should have a counter to count down timer to send out resource.
		return resource.resourceAmount;
	}

	public ResourceType GetResourceType()
	{
		return resource.resourceType;
	}

	public int GetResourceAmount()
	{
		return resource.resourceAmount;
	}

	public void OpenUpgradeMenu()
	{
		upgradeMenuCanvas.gameObject.SetActive (true);
	}

	public void CloseUpgradeMenu()
	{
		upgradeMenuCanvas.gameObject.SetActive (false);
	}

	public void ActivateTowerOnPlanet()
	{
		if (ResourceManager.instance.CostResource (ResourceType.MINERAL, upgradeCost)) {
			Debug.Log ("Activate tower on planet.");
			isTowerActivated = true;
			tower.SetActive (true);
			destroyedTower.SetActive (false);
			upgradeMenuCanvas.gameObject.SetActive (false);
		}
	}

	public void ActivateShieldOnPlanet()
	{
		if (ResourceManager.instance.CostResource (ResourceType.POWER, 5000)) {
			shield.SetActive (true);
			isShieldActivated = true;
		}
	}
		
	void OnTriggerEnter2D(Collider2D coll) {
		if (!isDetected) {
			return;
		}
		if (!isShieldActivated && coll.gameObject.tag == "Enemy" && isTowerActivated) {
			isTowerActivated = false;
			tower.SetActive (false);
			destroyedTower.SetActive (true);
		}
	}

	void OnDrawGizmos()
	{
		if (isDetected) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere (transform.position, 1);
		}
	}
}