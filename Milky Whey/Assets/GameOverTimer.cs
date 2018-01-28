using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour {

	private float timer = 0f;

	private Fading fade;
	bool startLoading = false;

	void Awake()
	{
		fade = GameObject.Find("Game Manager").GetComponent<Fading>();
	}

	// Use this for initialization
	void Start () {
		timer = 0f;


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene (0);
		}
		timer += Time.deltaTime;

		if (timer >= 10.0f) {
			if (!startLoading) {
				StartCoroutine (FadeWait (0));
				startLoading = true;
			}
		}
	}

	IEnumerator FadeWait(int sceneIndex)
	{
		float fadeTime = fade.BeginSceneFade(1);
		fade.BeginAudioFade(1);
		Time.timeScale = 1;
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(sceneIndex);
	}
}
