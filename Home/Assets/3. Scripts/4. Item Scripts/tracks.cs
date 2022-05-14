using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracks : MonoBehaviour
{
    Transform Ply_target;
    Transform Trc_target;
    //ItemSpwan Item;
    

    public bool trackCheck = true;
    public Quaternion rot;
    

    void Start()
    {
        Ply_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Trc_target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>();
        //Item = GetComponent<ItemSpwan>();
        
    }

    
    void Update()
    { 
        Distance_Dir();
        
    }

    public Quaternion Distance_Dir()
    {
        Vector2 len = Trc_target.transform.position - Ply_target.transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
              
        rot = Quaternion.Euler(0, 0, z - 90);
        return rot;
    }


  
}
