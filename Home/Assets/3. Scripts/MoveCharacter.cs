using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private float walkSpeed;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        position.x += walkSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Credit")
        {
            onCredit();
        }
    }

    [SerializeField] private GameObject credit;
    void onCredit()
    {
        credit.SetActive(true);
    }
}