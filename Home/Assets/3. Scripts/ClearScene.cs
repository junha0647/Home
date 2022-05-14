using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : MonoBehaviour
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
}