using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Graph
{
    internal List<Vertex> verteces;
    internal List<Edge> edges;

    internal Graph(List<Vertex> verteces, List<Edge> edges)
    {
        this.verteces = verteces;
        this.edges = edges;
    }

}
