using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScenes : MonoBehaviour
{
    [SerializeField] private string SceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.SceneMovement(SceneName);
    }
}
