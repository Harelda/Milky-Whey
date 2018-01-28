using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRadiusManager : MonoBehaviour {


	public GameObject[] levelRadiuses;
	private int currentLevel = 0;


	// Use this for initialization
	void Start () {
		currentLevel = GetComponent<ResourcePlanetFetching> ().currentLevel;

		for (int i = 0; i < levelRadiuses.Length; i++) {
			levelRadiuses [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentLevel = GetComponent<ResourcePlanetFetching> ().currentLevel;
		for (int i = 0; i < currentLevel; i++) {
			levelRadiuses [i].SetActive (true);
		}
	}
}
