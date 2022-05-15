using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracks : MonoBehaviour
{
    SpriteRenderer spr;
    ItemSpwan item;

    public bool doll;
    public bool trac;

    

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        item = GetComponent<ItemSpwan>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            spr.enabled = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            if (doll)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            if (trac)
            {
                Destroy(this.gameObject);
            }
            else if(doll)
            {
                spr.enabled = false;
            }
        }

        if (collision.gameObject.tag == "Tile")
        {
            if (doll)
            {
                //Debug.Log("인형삭제");
                Destroy(this.gameObject);
            }
            if (trac)
            {
                //Debug.Log("발삭제");
                Destroy(this.gameObject);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            if (doll)
            {
                //Debug.Log("인형삭제");
                Destroy(this.gameObject);
            }

            if (trac)
            {
                //Debug.Log("발삭제");
                Destroy(this.gameObject);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spawn")
        {
            if (trac)
            {
                //Debug.Log("발삭제");
                Destroy(this.gameObject);
            }
        }
    }


}
