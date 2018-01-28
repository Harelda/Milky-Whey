using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour {

	public GameObject resourcePlanets;
	public int tutorialLine=0;

	public GameObject[] animations;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		resourcePlanets.SetActive(true);
		if (Input.GetMouseButtonDown (0)) {
			tutorialLine++;
		}

		switch(tutorialLine)
		{
		case 2:
			animations [0].SetActive (true);
			break;
		case 4:
			animations [0].SetActive (false);
			animations [1].SetActive (true);
			break;
		case 6:
			animations [1].SetActive (false);
			animations [0].SetActive (true);
			break;
			case 10:
			animations [0].SetActive (false);
			animations [2].SetActive (true);
			break;
			case 14:
			animations [2].SetActive (false);
			animations [3].SetActive (true);
			break;
		case 16:
			SceneManager.LoadScene (10);
			break;
		}



	}
}
