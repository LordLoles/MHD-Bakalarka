using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPathComparator : IComparer<List<Edge>>
{
    public int Compare(List<Edge> x, List<Edge> y)
    {
        int ret;
        
        ret = getLast(x).value.CompareTo(getLast(y).value);
        if (ret != 0) return ret;

        ret = getTransfers(x).CompareTo(getTransfers(y));
        if (ret != 0) return ret;

        ret = findFirstLinkVertex(x).time.CompareTo(findFirstLinkVertex(y).time) * (-1);
        if (ret != 0) return ret;

        ret = getPreLast(x).sections.CompareTo(getPreLast(y).sections);
        return ret;
    }


    private Vertex getPreLast(List<Edge> path)
    {
        return path[path.Count - 1].fromV;
    }

    private Vertex getLast(List<Edge> path)
    {
        Edge e = path[path.Count - 1];
        if (e.waitingEdge) return e.fromV;
        return e.toV;
    }


    private int getTransfers(List<Edge> path)
    {
        Edge e = path[path.Count - 1];
        Vertex v = e.fromV;
        int trans = v.transfers;

        if ((!e.waitingEdge) && (path.Count >= 2) && (path[path.Count - 2].linkID != e.linkID)) trans++;

        return trans;
    }


    private Edge findFirstLink(List<Edge> path)
    {
        for (int i = 0; i < path.Count-1; i++)
        {
            if (!path[i].waitingEdge) return path[i];
        }

        return path[path.Count -1];
    }


    private Vertex findFirstLinkVertex(List<Edge> path)
    {
        return findFirstLink(path).fromV;
    }

}
