using UnityEngine;
using System.Collections;

public class Edge : GraphObject
{
    public Node left, right;

    public void UpdateEdge()
    {
        if (left == null || right == null)
            return;

        transform.position = (left.transform.position + right.transform.position) / 2f;
        Vector3 distance = left.rect.anchoredPosition - right.rect.anchoredPosition;
        transform.right = distance;
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, distance.magnitude);
        text.transform.up = Vector3.up;
    }

    public void SetVertexes(Node left, Node right)
    {
        this.left = left;
        this.right = right;
        UpdateEdge();
    }

    public string GetPair()
    {
        return ("<" + left.Label + ", " + right.Label + ">");
    }
}