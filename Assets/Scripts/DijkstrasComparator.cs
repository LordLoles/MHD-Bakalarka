using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class DijkstrasComparator : IComparer<Vertex>
{

    public int Compare(Vertex x, Vertex y)
    {
        int ret = x.value.CompareTo(y.value);
        if (ret != 0) return ret;
        else return x.name.CompareTo(y.name);
    }
}