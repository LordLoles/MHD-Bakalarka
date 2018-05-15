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
        return makePath(v, new List<Edge>());
    }


    public List<Edge> makePath(Vertex v, List<Edge> path)
    {
         if (v == null)
         {
             return null;
         }
         makePath(v.parent, path);
         if (v.parent != null)
         {
             //two verteces has been found
             //now we need to print the edge in between, if it isn't waiting
             if (!v.toParent.waitingEdge) path.Add(v.toParent);
         }
         return path;
    }

}
