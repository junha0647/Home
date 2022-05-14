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


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if(!ItemCheck)
        {
            StartCoroutine("Spawn", SpawnTime);
        }
    }

    private IEnumerator Spawn(float delyTime)
    {
        
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Item, spawnPos, Quaternion.identity);
        ItemList.Add(instance);
        ItemCheck = true;
        area.enabled = false;
        
        yield return new WaitForSeconds(delyTime);
        
        
        
    }

    public bool ItemChecks(bool item)
    {
        return ItemCheck = item;
    }

    

    private Vector2 GetRandomPosition()
    {
        basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-100f, 100f);
        float posY = basePosition.y + Random.Range(-100f, 100f);

        Vector2 spawnPos = new Vector2(posX, posY);
        basePosition = spawnPos;

        return spawnPos;
    }
}
