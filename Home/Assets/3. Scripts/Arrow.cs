using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private int rotateSpeed;
    [SerializeField] private Transform tr;

    void Update()
    {
        if(tr != null)
        {
            Vector2 direction = new Vector2(transform.position.x - tr.position.x, transform.position.y - tr.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
