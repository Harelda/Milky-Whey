using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmailTimer : MonoBehaviour {

	private float timer = 0f;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene (3);
		}
		timer += Time.deltaTime;

		if (timer >= 10.0f) {
			SceneManager.LoadScene (3);
		}
	}
}
