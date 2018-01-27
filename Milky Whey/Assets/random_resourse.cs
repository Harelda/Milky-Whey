using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_resourse : MonoBehaviour {
    public int health = 1;
    public int energy_prove = 0;
    public int money_prove = 0;
    public int other_prove = 0;
    public bool in_range = false;
    public bool line_of_sight = false;


    // Use this for initialization
    void Start () {
        int res_type = Random.Range(0, 3);
        if (res_type == 0){
            energy_prove = 25;
        }
        else if(res_type == 1)
        {
            money_prove = 25;
        }
        else if(res_type == 2)
        {
            other_prove = 25;
        }
    }
    

    // Update is called once per frame
    void Update () {

        
        
    }
}
