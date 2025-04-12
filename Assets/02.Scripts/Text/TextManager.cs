using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [Header("대사 UI")]
    [SerializeField] private GameObject _textArea;
    [SerializeField] private TextMeshProUGUI _lineText;
    [SerializeField] private GameObject _keyIcon;

    [Header("대사 데이터")]
    [SerializeField] private TextSO _textSO;
    [SerializeField] private float _nextlineTime;
   
    private int _lineIndex = 0;

    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        
    }
    private void Start()
    {
        _keyIcon.SetActive(false);
        _textArea.SetActive(false);
    }
    private void Update()
    {
        if (_keyIcon.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            _boxCollider.enabled = false;

            GameManager.Instance.textflage = true; 
            _textArea.SetActive(true);
            StartTalking(_textSO.text);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PLAYER"))
        {
            _keyIcon.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PLAYER"))
        {
            _keyIcon.SetActive(false);
        }
    }

    public void StartTalking(string[] talk)
    {
        StartCoroutine(TextRoutine(talk[_lineIndex]));
    }

    private void NextTalk()
    {
        _lineText.text = "";

        _lineIndex++;
        if(_lineIndex >= _textSO.text.Length)
        {
            EndTalking();
            return;
        }

        StartCoroutine(TextRoutine(_textSO.text[_lineIndex]));
    }

    private void EndTalking()
    {
        _lineIndex = 0;
        _textArea.SetActive(false);
        _boxCollider.enabled = true;
        GameManager.Instance.textflage = false;
    }

    IEnumerator TextRoutine(string line)
    {
        _lineText.text = "";

        for(int i=0; i<line.Length; i++)
        {
            _lineText.text += line[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(_nextlineTime);
        NextTalk();
    }
}
