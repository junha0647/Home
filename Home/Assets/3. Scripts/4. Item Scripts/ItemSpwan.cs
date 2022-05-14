using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpwan : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    public GameObject Item;
    [Header("���� �ð�")]
    public float SpawnTime = 5;
    [Header("������ üũ")]
    [SerializeField] private bool Check = false;
    [Header("���� ����")]
    private BoxCollider2D area;
    [Header("���� �迭")]
    private List<GameObject> ItemList = new List<GameObject>();
    public Vector2 basePosition;


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        basePosition = transform.position;
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
        /*
        for(int i = 0; i < count; i++)
        {
            Vector3 spawnPos = GetRandomPosition();

            GameObject instance = Instantiate(monster, spawnPos, Quaternion.identity);
            monsterList.Add(instance);
        }*/
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Item, spawnPos, Quaternion.identity);
        ItemList.Add(instance);
        Check = true;
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
        /*
        if (Check == false)
        {
            StartCoroutine("Spawn", SpawnTime);
        }
        */
        
    }

    

    private Vector2 GetRandomPosition()
    {
        
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-10f, 10f);
        float posY = basePosition.y + Random.Range(-10f, 10f);

        Vector2 spawnPos = new Vector2(posX, posY);
        basePosition = spawnPos;

        return spawnPos;
    }
}
