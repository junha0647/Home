using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackSpwan : MonoBehaviour
{
    Transform Ply_target;
    Transform Trc_target;

    [Header("스폰 오브젝트")]
    public GameObject tracked;
    [Header("스폰 시간")]
    public float SpawnTime;
    
    [Header("생성 범위")]
    private BoxCollider2D area;
    [Header("생성 배열")]
    private List<GameObject> trackList = new List<GameObject>();
    public Quaternion rot;
    private Vector2 len;

    public bool check = false;

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Ply_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Trc_target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>();
        len = Trc_target.transform.position - Ply_target.transform.position;

        Distance_Dir();

        
        if (!check)
        {
            StartCoroutine("Spawn", SpawnTime);
        }

    }

    private IEnumerator Spawn(float delyTime)
    {
        
        Vector3 spawnPos = GetRandomPosition();
        
        GameObject instance = Instantiate(tracked, spawnPos, rot);
        trackList.Add(instance);
        check = true;
        //Debug.Log("발생성");
        yield return new WaitForSeconds(1f);
        area.enabled = false;
        yield return new WaitForSeconds(delyTime);
        

        area.enabled = true;
        check = false;
    }

    public Quaternion Distance_Dir()
    {
        
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;

        rot = Quaternion.Euler(0, 0, z - 90);
        return rot;
    }


    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = Ply_target.transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 4f, size.x / 4f);
        float posY = basePosition.y + Random.Range(-size.y / 4f, size.y / 4f);

        Vector2 spawnPos = new Vector2(posX, posY);
        
        return spawnPos;
    }

}
