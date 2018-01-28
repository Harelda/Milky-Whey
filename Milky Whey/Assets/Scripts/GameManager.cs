using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Spawner spawner;
    public Spawner plebSpawner;

    public Text dialogBox;
    public Image avatarImage;

    public ClickManager clickManager;

	// Use this for initialization
	void Start () {
        spawner.enabled = false;
        plebSpawner.enabled = false;

        dialogBox.enabled = true;
        avatarImage.enabled = true;

        clickManager.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
