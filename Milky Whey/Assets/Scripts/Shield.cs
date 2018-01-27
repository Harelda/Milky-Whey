using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    public float rotationSpeed;
    public float startingRotation;
    public float radius;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        rb2d.rotation = startingRotation;
        rb2d.position = radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.A)) {
            rb2d.MoveRotation(rb2d.rotation + rotationSpeed * Time.deltaTime);
            rb2d.MovePosition(radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180)));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.MoveRotation(rb2d.rotation - rotationSpeed * Time.deltaTime);
            rb2d.MovePosition(radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180)));
        }
    }
}
