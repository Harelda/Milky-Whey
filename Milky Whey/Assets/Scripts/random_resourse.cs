using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_resourse : MonoBehaviour {
    public int health = 1;
    public int min_prove = 0;
    public int gas_prove = 0;
    public int power_prove = 0;
    public bool in_range = false;
    public bool line_of_sight = false;
    private int res_type = -1;
    public int max_gas_planet = 1;
    
    // Use this for initialization
    void Start () {

        float dist_from_zero = Vector2.Distance(transform.position, Vector2.zero);
 
        
        float rng = Random.value;
        if (rng < 0.3 && dist_from_zero > 4)
        {
            res_type = 0;    //gas
            gas_prove = 25;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);
            max_gas_planet = max_gas_planet - 1;

        }
        else
        {
            rng = Random.value;
            if (rng < 0.5)
            {
                res_type = 1; //miniral
                min_prove = 25;
                GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);
            }
            else
            {
                res_type = 2; //power
                power_prove = 25;
                GetComponent<SpriteRenderer>().color = new Color(1, 0.92f, 0.016f, 1);
                ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);
            }
        }

    }
    

    // Update is called once per frame
    void Update () {

        
        
    }
}
