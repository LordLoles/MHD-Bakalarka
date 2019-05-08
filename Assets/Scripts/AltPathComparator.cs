using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPathComparator : IComparer<List<Edge>>
{
    public int Compare(List<Edge> x, List<Edge> y)
    {
        Vertex vx = getPreLast(x);
        Vertex vy = getPreLast(y);
        int ret;

        ret = vx.value.CompareTo(vy.value);
        if (ret != 0) return ret;

        ret = findFirstLinkVertex(x).time.CompareTo(findFirstLinkVertex(y).time) * (-1);
        if (ret != 0) return ret;

        ret = vx.sections.CompareTo(vy.sections);
        return ret;
    }


    private Vertex getPreLast(List<Edge> path)
    {
        return path[path.Count - 1].fromV;
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
