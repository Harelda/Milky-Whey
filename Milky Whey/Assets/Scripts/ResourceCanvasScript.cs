using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCanvasScript : MonoBehaviour {

	public Text[] resourceTexts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<resourceTexts.Length;i++)
		{
			resourceTexts [i].text = ResourceManager.instance.resources [i].ToString();
		}
	}
}
