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
	public Canvas upgradeMenuCanvas;

	// Use this for initialization
	void Start () {
		upgradeMenuCanvas.gameObject.SetActive (false);
	}


	
	// Update is called once per frame
	void Update () {
		
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
		Debug.Log ("Activate tower on planet.");
	}
}
