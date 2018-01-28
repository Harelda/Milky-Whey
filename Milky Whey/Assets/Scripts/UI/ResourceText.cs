using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour {
    private Text[] resourceTexts;

	// Use this for initialization
	void Start () {
        resourceTexts = transform.GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < resourceTexts.Length; i++)
        {
            resourceTexts[i].text = (ResourceManager.instance.resources[i] / 1000).ToString();
        }
    }
}
