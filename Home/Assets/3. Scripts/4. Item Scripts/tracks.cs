using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracks : MonoBehaviour
{
    SpriteRenderer spr;
    public bool doll;
    public bool trac;
    

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        
    }

    
    void Update()
    { 
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            spr.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            if (trac)
            {
                Destroy(this.gameObject);
            }else if(doll)
            {
                spr.enabled = false;
            }
        }
    }


}
