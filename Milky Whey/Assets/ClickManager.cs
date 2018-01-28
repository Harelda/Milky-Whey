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

				ResourcePlanet rp = hit.collider.gameObject.GetComponent<ResourcePlanet> ();
				if (rp.isDetected && !rp.isTowerActivated) {
					if (!rp.upgradeMenuCanvas.gameObject.activeInHierarchy) {
						rp.OpenUpgradeMenu ();
					} else {
						rp.CloseUpgradeMenu ();
					}
				}
			}

            if (hit.collider != null && hit.collider.tag == "Shield")
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.gameObject.GetComponent<Shield>().setActiveShield();


            }

			if (hit.collider != null && hit.collider.tag == "Player") {
				Debug.Log(hit.collider.gameObject.name);

				ResourcePlanetFetching rpf = hit.collider.gameObject.GetComponent<ResourcePlanetFetching> ();
				if (!rpf.upgradeMenuCanvas.gameObject.activeInHierarchy && rpf.currentLevel < rpf.resourcePlanets.Length) {
					rpf.OpenUpgradeMenu ();
				} else {
					rpf.CloseUpgradeMenu ();
				}
			}
        }

		if (Input.GetMouseButtonDown(1)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null && hit.collider.tag == "ResourcePlanet") {
				if (hit.collider.gameObject.GetComponent<ResourcePlanet> ().isTowerActivated) {
					hit.collider.gameObject.GetComponent<ResourcePlanet> ().ActivateShieldOnPlanet ();
				}
			}
		}
	}
}
