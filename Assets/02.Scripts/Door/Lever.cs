using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject _eKeyIcon;
   
    private Door _door;
    private Animator _animator;
    private int _onParamterHash = Animator.StringToHash("On");
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _door = GetComponentInChildren<Door>();
       
    }
    private void Update()
    {
        if(_eKeyIcon.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger(_onParamterHash);
            _door.enabled = true;
            SoundManager.Instance.PlaySound(SoundManager.Sound.Leber);

        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("PLAYER"))
        {
            _eKeyIcon.SetActive(true);
        }
    }
}
