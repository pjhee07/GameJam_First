using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove; //�ൿ��ǥ�� ������ ����
    SpriteRenderer spriteRenderer;
    Vector2 frontVec;
    Enemy enemy;
    PlayerHp playerHp;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
        playerHp = GameObject.FindWithTag("Player").GetComponent<PlayerHp>();
    }

    private void Update()
    {
        Facing();
        Attack();
    }
    void FixedUpdate()
    {
        //�� '����'���θ� �˾Ƽ� �����̰�
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //�÷��� üũ
        //���ʹ� ���� üũ�ؾ�
        frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //������,����,����

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("TILEMAP")); //����,����,�Ÿ�,���̾��ũ

        if (rayHit.collider == null)
        {
            Debug.Log("���! �� �� ����������!");
            nextMove = nextMove * (-1); // ���������� ������ 1�� ����
            CancelInvoke(); //��� Invoke�Լ��� ���߰� �ٽ� ����
            Invoke("Think", 5);
            //��, ���������� ����� �� Invoke �Լ��� ������ ������
            //1�� ���� �ϴ��� 5�ʰ� ������ ������ ������ ���� ������ ���ϰ� ������
            //CancelInvoke�� ��������ν� 5�� �����̶� ���������� ������ �ٷ� ������ �ٲ���� �� �ִ�.

        }
    }
    //�ൿ��ǥ�� �ٲ��� �Լ� ���� ---> ����Ŭ���� Ȱ��

    void Think()
    {
        nextMove = Random.Range(-1, 2); //-1�̸� ����, 0�̸� ���߱�, 
        // 1�̸� ���������� �̵�
        Invoke("Think", 5);
    }

    void Facing()
    {
        if (nextMove < 0)
            spriteRenderer.flipX = false;
        else if (nextMove > 0)
            spriteRenderer.flipX = true;
        //0�϶��� �״��

    }

    void Attack()
    {
        RaycastHit2D DetectPlayer = Physics2D.Raycast(frontVec, new Vector2(nextMove, 0), enemy.atkDistance, LayerMask.GetMask("PLAYER"));
        if(DetectPlayer.collider != null)
        {
            //���� �ִϸ��̼� action 
            //����ũ���̹��� enemy.���ݷ�-=
            TakgeDamage(enemy.atkDmg, playerHp.currentHp);
        }
    }

    void TakgeDamage(int damage, int targetHp)
    {
        targetHp -= damage;
    }


}
