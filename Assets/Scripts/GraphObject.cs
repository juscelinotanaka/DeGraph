using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class GraphObject : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    private Color lastColor;
    public RectTransform rect;
    protected Text text;

    public string Label
    {
        get { return text.text; }
        set { text.text = value; }
    }

    void Awake()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        text = GetComponentInChildren<Text>();
    }

    public void Select()
    {
        lastColor = img.color;
        img.color = Color.green;
    }

    public void Deselect()
    {
        img.color = lastColor;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Selector.SetSelected(this);
    }
}
