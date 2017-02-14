using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    public static GraphManager Instance;

    public GameObject nodePrefab;
    public GameObject edgePrefab;

    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();

    public Text nodesText, edgesText;

    void Awake()
    {
        Instance = this;
    }

    void UpdateNodeList()
    {
        string nodeList = "";
        for (int i = 0; i < nodes.Count; i++)
        {
            nodeList += nodes[i].Label + "\n";
        }
        nodesText.text = nodeList;
    }

    void UpdateEdgeList()
    {
        string edgeList = "";
        for (int i = 0; i < edges.Count; i++)
        {
            edgeList += edges[i].Label + ":" +edges[i].GetPair() + "\n";
        }
        edgesText.text = edgeList;
    }

    void CreateNode()
    {
        GameObject node = Instantiate(nodePrefab);
        node.transform.SetParent(transform);
        node.transform.localScale = Vector3.one;
        node.transform.position = Input.mousePosition;
        node.transform.SetSiblingIndex(transform.childCount - 1);

        Node n = node.GetComponent<Node>();
        n.Label = GetLetter(nodes.Count);

        nodes.Add(n);

        UpdateNodeList();
    }

    private string GetLetter(int number, bool lowerCase = false)
    {
        string output = "";
        char c = (char) ((lowerCase ? 97 : 65) + number);
        output += c;
        return output;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            CreateNode();
        }
    }

    public Edge CreateEdge(Node origin, Node destiny)
    {
        GameObject edge = Instantiate(edgePrefab);
        edge.transform.SetParent(transform);
        edge.transform.localScale = Vector3.one;
        edge.transform.SetSiblingIndex(0);

        Edge e = edge.GetComponent<Edge>();
        e.SetVertexes(origin, destiny);
        e.Label = GetLetter(edges.Count, true);

        edges.Add(e);

        UpdateEdgeList();

        return e;
    }
}