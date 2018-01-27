using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    public int activeShield = 0;

    public Shield[] shields;
    public SpriteRenderer[] sprites;

    // Use this for initialization
    void Start () {
        foreach (Shield shield in shields)
        {
            shield.enabled = false;
        }

        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = new Color(255, 255, 255);
        }

        shields[activeShield].enabled = true;
        sprites[activeShield].color = new Color(255, 255, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                shields[activeShield].enabled = false;
                sprites[activeShield].color = new Color(255, 255, 255);
                if (activeShield + 1 >= shields.Length)
                {
                    activeShield = 0;
                }
                else
                {
                    activeShield++;
                }

                shields[activeShield].enabled = true;
                sprites[activeShield].color = new Color(255, 255, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                shields[activeShield].enabled = false;
                sprites[activeShield].color = new Color(255, 255, 255);
                if (activeShield - 1 < 0)
                {
                    activeShield = shields.Length - 1;
                }
                else
                {
                    activeShield--;
                }

                shields[activeShield].enabled = true;
                sprites[activeShield].color = new Color(255, 255, 0);
            }
        }
	}
}
