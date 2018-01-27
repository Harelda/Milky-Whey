using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_resourse : MonoBehaviour {
    private int health = 1;
    private int energy_prove = 0;
    private int money_prove = 0;
    private int other_prove = 0;
    private bool in_range = false;
    


    // Use this for initialization
    void Start () {
        int rng = Rand.Range(0, 3);

        print(rng);
    }
    

    // Update is called once per frame
    void Update () {
        
        
}
}
