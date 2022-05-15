using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�÷��̾� �ӵ�")]
    [SerializeField] private float Speed;

    Rigidbody2D rigid;
    Animator anim;

    float h, v;
    bool isHorizonMove;

    [SerializeField] private SoundManager soundManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDie != true)
        {
            Move();
        }
        onDie();
    }

    // �̵�
    void Move()
    {
        // �̵� ��
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // wasd ��ư ����
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        // wasd ��ư ��
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // ���� �̵�����, ���� �̵����� �Ǻ�
        if (hDown)
        {
            isHorizonMove = true;
            soundManager.PlaySound("Walk");
        }
        else if (vDown)
        {
            isHorizonMove = false;
            soundManager.PlaySound("Walk");
        }
        else if (hUp || vUp)
        {
            isHorizonMove = h != 0;
            soundManager.StopSound("Walk");
        }

        // �ִϸ��̼�
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }

    [SerializeField] private HP hp;
    [SerializeField] private Hint hint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            hint.getHint();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            hp.HealthDown();
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            Debug.Log("�ѵ�");
        }
    }
    bool isDie = false;
    void onDie()
    {
        if (hp.HPValue == 0)
        {
            isDie = true;
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
}
