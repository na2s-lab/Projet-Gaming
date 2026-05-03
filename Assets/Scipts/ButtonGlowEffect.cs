using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGlowEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    public Color normalColor = new Color(0.3f, 0f, 0.5f, 1f);    // violet sombre
    public Color glowColor = new Color(0.7f, 0f, 1f, 1f);        // violet lumineux
    public float speed = 5f;

    private Color targetColor;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.color = normalColor;
        targetColor = normalColor;
    }

    void Update()
    {
        buttonImage.color = Color.Lerp(buttonImage.color, targetColor, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetColor = glowColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetColor = normalColor;
    }
}