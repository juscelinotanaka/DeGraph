using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : GraphObject, IDragHandler, IPointerDownHandler
{
    public Text label;
    private bool dragged;
    public List<Edge> edges = new List<Edge>();
    private Vector3 offset;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
        dragged = true;
        UpdateEdges();
    }

    private void UpdateEdges()
    {
        for (int i = 0; i < edges.Count; i++)
        {
            edges[i].UpdateEdge();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragged = false;
        offset = transform.position - Input.mousePosition;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!dragged)
            base.OnPointerClick(eventData);
    }

    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
    }
}
