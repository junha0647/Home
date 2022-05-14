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
    [SerializeField] private bool Check = false;
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
        if(!Check)
        {
            StartCoroutine("Spawn", SpawnTime);
        }
    }

    private IEnumerator Spawn(float delyTime)
    {
        
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Item, spawnPos, Quaternion.identity);
        ItemList.Add(instance);
        Check = true;
        area.enabled = false;
        
        yield return new WaitForSeconds(delyTime);
        
        
        
    }

    

    private Vector2 GetRandomPosition()
    {
        basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-30f, 30f);
        float posY = basePosition.y + Random.Range(-30f, 30f);

        Vector2 spawnPos = new Vector2(posX, posY);
        basePosition = spawnPos;

        return spawnPos;
    }
}
