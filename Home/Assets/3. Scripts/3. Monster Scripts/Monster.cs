using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigidChild;
    Rigidbody2D rigid;
    Transform target;
    Animator anim;
    SpriteRenderer spriteRenderer;
    

    [Header("�߰� �ӵ�")]
    [SerializeField][Range(1f, 8f)] float moveSpeed = 1f;

    [Header("���� �Ÿ�")]
    [SerializeField][Range(0f, 3f)] float contactDistance = 1f;

    bool follow = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidChild = GetComponentInChildren<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        Dir();
    }

    // Ÿ���� �Ѵ� ��
    void FollowTarget()
    {
        if((Vector2.Distance(transform.position, target.position) > contactDistance) && follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            //rigidChild.velocity = Vector2.zero;
            anim.SetBool("IsWalking", false);
        }
    }

    // �ִϸ��̼� ��ȯ�� ���� ���� ��
    void Dir()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.y = 0f;
        if(dir.x < 0)
        {
            spriteRenderer.flipX = false;
        }else if(dir.x > 0)
        {
            spriteRenderer.flipX = true;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            follow = true;
            anim.SetBool("IsWalking", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            follow = false;
            anim.SetBool("IsWalking", false);
        }
    }
}
