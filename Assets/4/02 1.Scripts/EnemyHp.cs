using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1.7f;

    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //ü�¹ٸ� �����ϵ� canvas�� �ڽ����� �����ϰ�, ü�¹��� ��ġ ������ ���� �ϱ� ���� hpBar�� �����Ѵ�.
    }

    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //worldToScreenPoint
        hpBar.position = _hpBarPos;
    }
}
