using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private float Speed;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        position.x -= Speed * Time.deltaTime;
        transform.position = position;
    }
}