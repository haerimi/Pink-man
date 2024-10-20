using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeMove : MonoBehaviour
{

    Rigidbody2D rigid;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }


    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

    }
    /*
    Rigidbody2D rigid;
    public int nextMove;    // 행동 지표를 결정하는 변수

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 5);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Object"));

        if (rayHit.collider == null) {
           nextMove = nextMove * -1;
           CancelInvoke();
           Invoke("Think", 5);
        }
    }

    // 행동 지표를 바꿔줄 함수
    void Think() {
        nextMove = Random.Range(-1, 2); // 최소, 최대

        float nextThinkTime = Random.Range(2f, 5f);

        Invoke("Think", nextThinkTime);
    }*/
}
