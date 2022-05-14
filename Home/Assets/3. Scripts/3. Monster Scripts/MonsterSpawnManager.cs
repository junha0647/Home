using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [Header("스폰 오브젝트")]
    public GameObject monster;
    [Header("스폰 시간")]
    public float SpawnTime;
    //[Header("생성 갯수")]
    //private int count = 10;
    [Header("생성 범위")]
    private BoxCollider2D area;
    [Header("생성 배열")]
    private List<GameObject> monsterList = new List<GameObject>();
    tracks track;


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", SpawnTime);
        track = GetComponent<tracks>();
    }

    private IEnumerator Spawn(float delyTime)
    {
        /*
        for(int i = 0; i < count; i++)
        {
            Vector3 spawnPos = GetRandomPosition();

            GameObject instance = Instantiate(monster, spawnPos, Quaternion.identity);
            monsterList.Add(instance);
        }*/
        Vector3 spawnPos = GetRandomPosition();
        

        
        GameObject instance = Instantiate(monster, spawnPos, Quaternion.identity);
        monsterList.Add(instance);
        

        area.enabled = false;
        yield return new WaitForSeconds(delyTime);

        
        area.enabled = true;
        StartCoroutine("Spawn", SpawnTime);
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
