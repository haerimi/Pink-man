using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    int direction;
    public float maxSpeed;
    public float jumpPower;
    public float h;
    int jumpcount = 0;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Vector3 dirVec;     // 플레이어가 바라보는 방향
    GameObject scanObject;
    public GameManager manager;
    //private bool isDead = false;

    public AudioClip audioJump;
    public AudioClip audioItem;
    public AudioClip deathClip;
    public AudioClip audioFinish;

    private AudioSource audioSource;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }


    private void Update()
    {
        if (manager.isAction == true)
            h = 0;
        else
            h = Input.GetAxisRaw("Horizontal");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (jumpcount < 2)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * 800f);
                jumpcount++;
                audioSource.clip = audioJump;
                audioSource.PlayOneShot(audioJump, 0.5f);
            }

        }

        // Stop seepd
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 방향전환
        if (manager.isAction == false && Input.GetButton("Horizontal")) {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                spriteRenderer.flipX = true;
                direction = -1;
            }
            else {
                spriteRenderer.flipX = false;
                direction = 1;
            }
        }
        // Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isRun", false);
        else
            anim.SetBool("isRun", true);

        // Derection
        if (hDown && direction == -1)    // 왼쪽
            dirVec = Vector3.left;

        else if (hDown && direction == 1)    // 오른쪽
            dirVec = Vector3.right;

        // 엔터로 대화창을 한다면?
        if (Input.GetKeyDown(KeyCode.Return) && scanObject != null)
            manager.Action(scanObject);

    }

    void FixedUpdate()
    {
        // Move seepd
        float h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max seepd
        if (rigid.velocity.x > maxSpeed) // 오른쪽 최대 스피드
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // 왼쪽 최대 스피드
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 1.0f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpcount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {

            // point, 아이템 한개씩 먹을 때 하나씩 증가
            // 딸기는 50점, 바나나는 100점, 키위는 300점

            bool isBerry = collision.gameObject.name.Contains("StrawBerry");
            bool isBanana = collision.gameObject.name.Contains("Bananas");
            bool isKiwi = collision.gameObject.name.Contains("Kiwi");

            if (isBerry)
                manager.stagePoint += 50;

            else if (isBanana)
                manager.stagePoint += 100;

            else if (isKiwi)
                manager.stagePoint += 300;

            collision.gameObject.SetActive(false);

            audioSource.clip = audioItem;
            audioSource.PlayOneShot(audioItem, 0.6f);


        }

        else if (collision.gameObject.tag == "Finish") {
            //다음 스테이지
            audioSource.clip = audioFinish;
            audioSource.PlayOneShot(audioFinish, 0.5f);
            // 로드 씬  

        }

        if (collision.gameObject.tag == "Enemy") {
            Debug.Log("이건 장애물이야!");
            OnDamaged(collision.transform.position);
        }

        void OnDamaged(Vector2 targetPos) {

            // Health Down
            // --에서 HealthDown으로
            manager.HealthDown();

            // 한대 맞아서 무적
            gameObject.layer = 14;

            // 플레이어 투명도
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            // 튕겨나감
            int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

            anim.SetBool("isTake", true);
            Invoke("DamegAni", 0.7f);
            Invoke("OffDamaged", 2);

        }


    }
    void OffDamaged()
    {
        gameObject.layer = 13;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void DamegAni() {
        anim.SetBool("isTake", false);

    }

    public void VelocityZero() {
        rigid.velocity = Vector2.zero;
        rigid.velocity = Vector2.zero;
    }

}
