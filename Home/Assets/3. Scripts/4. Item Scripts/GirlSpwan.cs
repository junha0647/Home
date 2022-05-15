using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlSpwan : MonoBehaviour
{
    [Header("스폰 오브젝트")]
    public GameObject Girl;
    [Header("아이템 체크")]
    public bool ItemCheck = false;
    [Header("생성 범위")]
    private BoxCollider2D area;
  

    public Vector2 basePosition;



    void Start()
    {
        area = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!ItemCheck)
        {
            Spawn();
        }
        
    }

    public void Spawn()
    {

        Vector3 spawnPos = GetRandomPosition();

        Girl.transform.position = spawnPos;

        ItemCheck = true;
 
    }



    public Vector3 GetRandomPosition()
    {
        basePosition = transform.position;
        Vector2 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 3f, size.x / 3f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        if ((posX > size.x && posX < -size.x) || (posY > size.y && posY < -size.y))
        {
            GetRandomPosition();
        }

        Vector3 spawnPos = new Vector2(posX, posY);


        return spawnPos;
    }

    

}
