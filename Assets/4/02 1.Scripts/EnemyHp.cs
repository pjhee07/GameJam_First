using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1.7f;
    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //UI�� ĵ���� �ȿ� �־����.
                                                                                       // UI�� transform�� �ƴ� RectRansform�� ���.
    }

    void Update()
    {
        Vector3 _hpBarPos =
            mainCam.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //���� ��ǥ�� ��ũ�� ��ǥ ��, UI��ǥ�� �ٲ���.
        hpBar.position = _hpBarPos; //��ũ�� ��ǥ�� �ٲ� ������ ü�¹ٸ� �̵�.
    }
}
