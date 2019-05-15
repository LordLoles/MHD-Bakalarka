using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker {

    private Graph graph;


    public PathMaker(Graph graph)
    {
        this.graph = graph;
    }


    public List<Edge> makePath(Vertex v)
    {
        List<Edge> path = makePath(v, new List<Edge>());
        path.Reverse();
        return path;
    }

    public List<Edge> makePath(Vertex v, List<Edge> path)
    {
        if (v == null) return null;

        if (v.parent != null)
        {
            //two verteces has been found
            //now we need to print the edge in between, unless it isn't waiting
            //or combined link edge

            if (v.toParent.name.Contains(" comb")) //processLink(v, path);
            {
                string linkName = v.toParent.name;
                linkName = linkName.Remove(linkName.Length - 5);
                Edge predecessor;
                Vertex now = v;
                while (true)
                {
                    predecessor = graph.getPredecessor(v.toParent.linkID, now);
                    if (predecessor == null || predecessor.toV.isThis(v.parent)) break;
                    path.Add(predecessor);
                    now = predecessor.fromV;
                }
            }
            else if (!v.toParent.waitingEdge) path.Add(v.toParent);
        }
        makePath(v.parent, path);
        return path;
    }

}
