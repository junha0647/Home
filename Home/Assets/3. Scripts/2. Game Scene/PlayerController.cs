using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("플레이어 속도")]
    [SerializeField] private float Speed;

    Rigidbody2D rigid;
    float h, v;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * Speed;
    }
}
