using System.Collections.Generic;

public class DijkstrasComparator : IComparer<Vertex>
{

    public int Compare(Vertex x, Vertex y)
    {
        int ret = x.value.CompareTo(y.value);
        if (ret != 0) return ret;

        ret = x.transfers.CompareTo(y.transfers);
        if (ret != 0) return ret;

        if (x.pathStart == null || y.pathStart == null) return 0;

        ret = x.pathStart.time.CompareTo(y.pathStart.time);
        if (ret != 0) return ret;

        return x.sections.CompareTo(y.sections);
    }
}