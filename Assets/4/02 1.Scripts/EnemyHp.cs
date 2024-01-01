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
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>(); //?
    }

    void Update()
    {
        Vector2 _hpBarPos =
            Camera.main.ScreenToWorldPoint(new Vector2(transform.position.x, transform.position.y + height));
        hpBar.position = _hpBarPos;
    }
}
