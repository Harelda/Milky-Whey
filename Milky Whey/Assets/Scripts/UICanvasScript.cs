using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasScript : MonoBehaviour {

	public Camera my_camera;

	void Awake()
	{
		my_camera = Camera.main;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.forward, my_camera.transform.rotation * Vector3.up);
		transform.position = transform.parent.position + new Vector3(0, 1, 0);
	}
}
