using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public enum ResourceType
{
	MINERAL=0,
	GAS,
	POWER,
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
	public GameObject tower;
	public GameObject shield;
	public bool isTowerActivated = false;
	public bool isShieldActivated = false;

	public Canvas upgradeMenuCanvas;

	private float timeCounter = 0.0f;
	private float shieldTimer = 3.0f;

	// Use this for initialization
	void Start () {
		upgradeMenuCanvas.gameObject.SetActive (false);
		tower.SetActive (false);
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
		if (ResourceManager.instance.CostResource (resource.resourceType, upgradeCost)) {
			Debug.Log ("Activate tower on planet.");
			isTowerActivated = true;
			tower.SetActive (true);
		}
	}

	public void ActivateShieldOnPlanet()
	{
		shield.SetActive (true);
		isShieldActivated = true;
	}
		
	void OnTriggerEnter2D(Collider2D coll) {
		if (!isShieldActivated && coll.gameObject.tag == "Enemy") {
			isTowerActivated = false;
			tower.SetActive (false);
			Destroy (coll.gameObject);
		} else if(coll.gameObject.tag == "Enemy") {
			Destroy (coll.gameObject);
		}
	}
}