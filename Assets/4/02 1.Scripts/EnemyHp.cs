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
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //체력바를 생성하되 canvas의 자식으로 생성하고, 체력바의 위치 변경을 쉽게 하기 위해 hpBar에 저장한다.
    }

    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //worldToScreenPoint
        hpBar.position = _hpBarPos;
    }
}
