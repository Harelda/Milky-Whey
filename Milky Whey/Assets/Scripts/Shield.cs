using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    public float rotationSpeed;
    public float startingRotation;
    public float radius;

    public Shield[] shields;

    public bool active;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb2d.rotation = startingRotation;
        rb2d.position = radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180));

        if (active)
        {
            sr.color = new Color(255, 255, 0);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.A) && active) {
            rb2d.MoveRotation(rb2d.rotation + rotationSpeed * Time.deltaTime);
            rb2d.MovePosition(radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180)));
        }

        if (Input.GetKey(KeyCode.D) && active)
        {
            rb2d.MoveRotation(rb2d.rotation - rotationSpeed * Time.deltaTime);
            rb2d.MovePosition(radius * new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180)));
        }
    }

    public void setActiveShield()
    {
        foreach (Shield shield in shields)
        {
            shield.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            shield.active = false;
        }

        active = true;
        sr.color = new Color(255, 255, 0);
    }
}
