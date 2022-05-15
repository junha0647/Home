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
    Transform Ply_target;


    bool MonCheck = false;

    void Start()
    {
        Ply_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        area = GetComponent<BoxCollider2D>();
        
    }

    int random = 0;
    private void Update()
    {
        if (!MonCheck)
        {
            StartCoroutine("Spawn", SpawnTime);
        }

        //random = Random.Range(0, 2);
    }

    private IEnumerator Spawn(float delyTime)
    {
        
        
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(monster, spawnPos, Quaternion.identity);
        monsterList.Add(instance);

        MonCheck = true;
        area.enabled = false;
        yield return new WaitForSeconds(delyTime);

        MonCheck = false;
        area.enabled = true;
        StartCoroutine("Spawn", SpawnTime);
    }

    float posX, posY;
    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = Ply_target.transform.position;
        Vector2 size = area.size;

        if(random == 0) // 양수
        {
            posX = basePosition.x + size.x * Random.Range(-0.5f, -0.25f); // -1f, -0.5f
            posY = basePosition.y + size.y * Random.Range(-0.5f, -0.25f); // 0.5f, 1f
            random = 1;
        }
        else if(random == 1) // 음수
        {
            posX = basePosition.x + size.x * Random.Range(0.25f, 0.5f); // -1f, -0.5f
            posY = basePosition.y + size.y * Random.Range(0.25f, 0.5f); // 0.5f, 1f
            random = 0;
        }

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}