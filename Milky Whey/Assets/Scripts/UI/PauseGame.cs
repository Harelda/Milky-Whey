using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    private GameObject menu;
    //private Home player;

    void Awake()
    {
        menu = GameObject.Find("Pause Menu");
        menu.SetActive(false);
        //player = GameObject.Find("Home").GetComponent<Home>();
    }

    // Update is called once per frame
    void Update() {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
