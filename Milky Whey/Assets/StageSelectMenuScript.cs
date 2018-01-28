using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectMenuScript : MonoBehaviour {

	public Button[] stageButtons;
	public Text[] stageTexts;
	public Image[] unknownPlanets;

	public Image[] lines;

	private int level=1;

	// Use this for initialization
	void Start () {
		
		level = PlayerPrefs.GetInt("Level");
        if (level == 0) level = 1; 
		for (int i = 0; i < level; i++) {
			stageButtons [i].gameObject.SetActive (true);
			stageTexts [i].gameObject.SetActive (true);
			unknownPlanets [i].gameObject.SetActive (false);
			if (i != 0) {
				lines [i - 1].gameObject.SetActive (true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel(int levelIndex)
	{
		SceneManager.LoadScene (levelIndex);
	}
}
