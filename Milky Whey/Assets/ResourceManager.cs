using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ResourceManager : MonoBehaviour {

	public int[] resources;


	public int winGas = 0;
	public int winPower = 0;
	public int winMineral = 0;

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
		if (WinningCondition (resources [0], resources [1], resources [2])) {
			EditorSceneManager.LoadScene ("Main Menu");
		}
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

	public bool WinningCondition(int gas, int power, int mineral)
	{
		if (gas > winGas && power > winPower && mineral > winMineral) {
			return true;
		} else {
			return false;
		}
	}
}