using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonClickEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    public float scaleAmount = 0.9f;
    public float duration = 0.1f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale * scaleAmount));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale));
    }

    IEnumerator ScaleTo(Vector3 target)
    {
        Vector3 start = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(start, target, elapsed / duration);
            yield return null;
        }
        transform.localScale = target;
    }
}
