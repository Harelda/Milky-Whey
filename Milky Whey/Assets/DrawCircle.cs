using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawCircle : MonoBehaviour
{

	float theta_scale = 0.01f;        //Set lower to add more points
	int size; //Total number of points in circle
	public float radius;
	LineRenderer lr;

	void Awake()
	{
		
		float sizeValue = (2.0f * Mathf.PI) / theta_scale;
		size = (int)sizeValue;
		size++;

		lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Additive"));
		lr.startWidth = 0.05f;
		lr.endWidth = 0.05f;
		lr.positionCount = size;
		lr.startColor = Color.red;
		lr.endColor = Color.red;
			
	}

	void Update()
	{
		Vector3 pos;
		float theta = 0f;

		for (int i = 0; i < size; i++) {
			theta += (2.0f * Mathf.PI * theta_scale);
			float x = radius * Mathf.Cos (theta);
			float y = radius * Mathf.Sin (theta);
			x += gameObject.transform.position.x;
			y += gameObject.transform.position.y;
			pos = new Vector3 (x, y, 0);
			lr.SetPosition (i, pos);
		}

	}
}