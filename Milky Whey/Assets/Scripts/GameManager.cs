﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int winningGasNeeded;
    //public int currentLevel;
    public int nextLevel;

    public Spawner spawner;
    public Spawner plebSpawner;

    public GameObject dialogBox;
    public GameObject avatarImage;

    public ClickManager clickManager;
    public ResourcePlanetFetching resourceFetching;

    public GameObject resourcePlanets;

    public Shield shield;

    public Home home;

    private Fading fade;

    private void Awake()
    {
        fade = GetComponent<Fading>();

		if (PlayerPrefs.GetInt ("Level") < nextLevel) {
			PlayerPrefs.SetInt ("Level", nextLevel - 1);
			PlayerPrefs.Save ();
		}
    }

    // Use this for initialization
    void Start () {
        spawner.enabled = false;
        plebSpawner.enabled = false;

        dialogBox.SetActive(true);
        avatarImage.SetActive(true);

        clickManager.enabled = false;
        resourceFetching.enabled = false;

        shield.active = false;

        resourcePlanets.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (WinningCondition(ResourceManager.instance.resources[0]))
        {
            home.won = true;
			if (nextLevel == 0) {
				StartCoroutine (FadeWait (11));	
			} else {
				StartCoroutine (FadeWait (nextLevel + 2));
			}
        }

        if (home.hp <= 0)
        {
            StartCoroutine(FadeWait(12));
        }
    }

    public void startLevel()
    {
        spawner.enabled = true;
        plebSpawner.enabled = true;

        dialogBox.SetActive(false);
        avatarImage.SetActive(false);

        clickManager.enabled = true;
        resourceFetching.enabled = true;

        shield.active = true;

        resourcePlanets.SetActive(true);
    }

    public bool WinningCondition(int gas)
    {
        return (gas >= winningGasNeeded);
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
