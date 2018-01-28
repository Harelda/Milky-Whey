using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    public int hp = 3;
    public bool won = false;

    private HpBar hpUI;

    private void Awake()
    {
        hpUI = GameObject.Find("Health Bar").GetComponent<HpBar>();
        won = false;
    }

    // Update is called once per frame
    void Update () {

	}

    public void takeDamage(int dmg)
    {
        if (!won)
        {
            hpUI.updateHealth(dmg);

            hp -= dmg;
        }
    }
}
