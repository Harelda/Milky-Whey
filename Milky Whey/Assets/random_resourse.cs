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
    public int res_type = -1;


    // Use this for initialization
    void Start () {
        int res_type = Random.Range(0, 3);
        if (res_type == 0){
            min_prove = 25;
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);

        }
        else if(res_type == 1)
        {
            gas_prove = 25;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);
        }
        else if(res_type == 2)
        {
            power_prove = 25;
            GetComponent<SpriteRenderer>().color = new Color(1, 0.92f, 0.016f, 1);
            ResourceManager.instance.AddCertainResource((ResourceType)res_type, 25);
        }

    }
    

    // Update is called once per frame
    void Update () {

        
        
    }
}
