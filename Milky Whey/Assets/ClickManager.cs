using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {
				Debug.Log(hit.collider.gameObject.name);

				hit.collider.gameObject.GetComponent<ResourcePlanet> ().OpenUpgradeMenu ();
				//hit.collider.attachedRigidbody.AddForce(Vector2.up);


			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {
				
				hit.collider.gameObject.GetComponent<ResourcePlanet> ().ActivateShieldOnPlanet ();

			}
		}
	}
}
