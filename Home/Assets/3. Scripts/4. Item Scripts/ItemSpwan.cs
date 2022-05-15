using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpwan : MonoBehaviour
{
    [Header("스폰 오브젝트")]
    public GameObject Item;
    [Header("스폰 시간")]
    public float SpawnTime = 5;
    [Header("아이템 체크")]
    public bool ItemCheck = false;
    [Header("생성 범위")]
    private BoxCollider2D area;
    [Header("생성 배열")]
    private List<GameObject> ItemList = new List<GameObject>();
    public Vector2 basePosition;
    int i = 0;


    void Start()
    {
        area = GetComponent<BoxCollider2D>();    
    }

    private void Update()
    {
        if(!ItemCheck)
        {
            Spawn(SpawnTime);
        }
        else
        {
            ItemChecks();
        }  
    }

    private void Spawn(float delyTime)
    {
        
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Item, spawnPos, Quaternion.identity);
        ItemList.Add(instance);
        ItemCheck = true;
        //area.enabled = false;
        
        //yield return new WaitForSeconds(delyTime);
  
    }

    private void ItemChecks()
    {
        if (ItemList[i] == null)
        {
            //Debug.Log(i);
            i++;
            ItemCheck = false;
        }
    }



    private Vector2 GetRandomPosition()
    {
        basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 3f, size.x / 3f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        if((posX > size.x && posX < -size.x) || (posY > size.y && posY < -size.y))
        {
            GetRandomPosition();
        }

        Vector3 spawnPos = new Vector2(posX, posY);
        

        return spawnPos;
    }
}