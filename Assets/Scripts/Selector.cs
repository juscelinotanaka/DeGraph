using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour
{
    public static GraphObject selectedObject;
    private static bool selectedThisFrame = false;

    public static void SetSelected(GraphObject obj)
    {
        //create edge if both are node
        if (selectedObject != null && selectedObject is Node && obj is Node)
        {
            Edge e = GraphManager.Instance.CreateEdge(selectedObject as Node, obj as Node);
            ((Node) selectedObject).AddEdge(e);
            ((Node) obj).AddEdge(e);
        }
        else
        {
            // deselect old object if one is already selected
            if (selectedObject != null)
                selectedObject.Deselect();

            selectedObject = obj;
            obj.Select();
            selectedThisFrame = true;
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedObject != null && !selectedThisFrame)
            {
                selectedObject.Deselect();
                selectedObject = null;
            }
            selectedThisFrame = false;
        }

    }
}