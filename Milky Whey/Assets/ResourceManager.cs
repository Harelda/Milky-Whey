using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	public int[] resources;

	public static ResourceManager instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;

	}

	// Use this for initialization
	void Start () {
//		for (int i = 0; i < resources.Length; i++) {
//			resources [i] = 0;
//		}
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void AddCertainResource(ResourceType resourceType, int resourceAmount)
	{
		resources [(int)resourceType] += resourceAmount;
	}

	public bool CostResource(ResourceType resourceType, int resourceAmount)
	{
		if (resources [(int)resourceType] - resourceAmount > 0) {
			resources [(int)resourceType] -= resourceAmount;
			return true;
		}
		return false;
	}
}
