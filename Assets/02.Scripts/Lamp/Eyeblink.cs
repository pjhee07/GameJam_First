using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Light2D

public class Eyeblink : MonoBehaviour
{
    [Header("References")] // 참조
    [SerializeField] private Light2D _light2D;
    [SerializeField] private GameObject _movement;

    private SpriteRenderer _spriteRenderer;

    [Header("Timings")]
    [SerializeField] private float _blinkInterval = 15f; // 간격
    [SerializeField] private float _fadeDuration = 1f;
    [SerializeField] private float _stateDelay = 7f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(BlinkLoop());
    }

    private IEnumerator BlinkLoop()
    {
        while (true)
        {
            yield return StartCoroutine(WaitAndOpenEyes());
            yield return new WaitForSeconds(_blinkInterval);
            yield return StartCoroutine(WaitAndCloseEyes());
        }
    }

    private IEnumerator WaitAndOpenEyes()
    {
        yield return new WaitForSeconds(_stateDelay);

        _movement.SetActive(true);
        StartCoroutine(FadeAlpha(_spriteRenderer, 0f, 1f));
        StartCoroutine(FadeAlpha(_light2D, 0f, 1f));
    }

    private IEnumerator WaitAndCloseEyes()
    {
        yield return new WaitForSeconds(_stateDelay);

        StartCoroutine(FadeAlpha(_spriteRenderer, 1f, 0f));
        StartCoroutine(FadeAlpha(_light2D, 1f, 0f));

        _movement.SetActive(false);
    }

    private IEnumerator FadeAlpha(SpriteRenderer renderer, float from, float to)
    {
        float t = 0f;
        while (t < _fadeDuration)
        {
            float alpha = Mathf.Lerp(from, to, t / _fadeDuration);
            Color color = renderer.color;
            color.a = alpha;
            renderer.color = color;

            t += Time.deltaTime;
            yield return null;
        }

        // Ensure exact target alpha
        Color finalColor = renderer.color;
        finalColor.a = to;
        renderer.color = finalColor;
    }

    private IEnumerator FadeAlpha(Light2D light, float from, float to)
    {
        float t = 0f;
        while (t < _fadeDuration)
        {
            float alpha = Mathf.Lerp(from, to, t / _fadeDuration);
            Color color = light.color;
            color.a = alpha;
            light.color = color;

            t += Time.deltaTime;
            yield return null;
        }

        // Ensure exact target alpha
        Color finalColor = light.color;
        finalColor.a = to;
        light.color = finalColor;
    }
}
