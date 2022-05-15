using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigidChild;
    Rigidbody2D rigid;
    Transform target;
    Animator anim;
    public SpriteRenderer spriteRenderer;

    

    [Header("추격 속도")]
    [SerializeField][Range(1f, 8f)] float moveSpeed = 1f;

    [Header("근접 거리")]
    [SerializeField][Range(0f, 3f)] float contactDistance = 1f;

    private Vector3 dir;
    bool follow = false;
    bool Die;

    // Start is called before the first frame update
    void Start()
    {
        rigidChild = GetComponentInChildren<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Die = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        Dir();
    }

    // 타갯을 쫓는 식
    void FollowTarget()
    {
        if((Vector2.Distance(transform.position, target.position) > contactDistance) && follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            anim.SetBool("IsWalking", true);
        }
        if(follow == false && Die)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime * 5f);
            //anim.SetBool("IsWalking", true);

            if (dir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (dir.x > 0)
            {
                spriteRenderer.flipX = false;
            }

            Destroy(gameObject, 1.5f);
        }
        
    }

    public float GetSpeed(float a)
    {
        moveSpeed = a;
        return moveSpeed;
    }

    // 애니메이션 전환을 위한 방향 값
    void Dir()
    {
        dir = target.transform.position - transform.position;
        dir.y = 0f;
       
        if(dir.x < 0 && follow)
        {
            spriteRenderer.flipX = false;
        }else if(dir.x > 0 && follow)
        {
            spriteRenderer.flipX = true;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.color = new Color(0, 0, 0, 255);
            follow = true;
            anim.SetBool("IsWalking", true);
        }

        if(collision.gameObject.tag == "Light")
        {
            spriteRenderer.color = new Color(255, 255, 255, 255);
            follow = false;
            Die = true;
        }
    }
  

    
}
