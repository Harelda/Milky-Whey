using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
    public int hp = 3;

    private HpBar hpUI;

    private void Awake()
    {
        hpUI = GameObject.Find("Health Bar").GetComponent<HpBar>();
    }

    // Update is called once per frame
    void Update () {

	}

    public void takeDamage(int dmg)
    {
        hpUI.updateHealth(dmg);

        hp -= dmg;
    }
}
