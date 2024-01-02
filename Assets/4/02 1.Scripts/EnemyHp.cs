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
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //UI는 캔버스 안에 있어야함.
                                                                                       // UI는 transform이 아닌 RectRansform을 사용.
    }

    void Update()
    {
        Vector3 _hpBarPos =
            mainCam.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0)); //월드 좌표를 스크린 좌표 즉, UI좌표로 바꿔줌.
        hpBar.position = _hpBarPos; //스크린 좌표로 바꾼 값으로 체력바를 이동.
    }
}
