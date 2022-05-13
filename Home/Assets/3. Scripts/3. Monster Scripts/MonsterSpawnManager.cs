using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    public GameObject monster;
    [Header("���� �ð�")]
    public float SpawnTime = 5;
    [Header("���� ����")]
    int count = 10;
    [Header("���� ����")]
    private BoxCollider2D area;
    [Header("���� �迭")]
    private List<GameObject> monsterList = new List<GameObject>();


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", SpawnTime);
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

        /*
        for(int i = 0; i < count; i++)
        {
            Destroy(monsterList[i].gameObject);
        }

        monsterList.Clear();
        area.enabled = true;
        */
        StartCoroutine("Spawn", SpawnTime);
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f); ;
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}