using System.Collections.Generic;

public class DijkstrasComparator : IComparer<Vertex>
{

    public int Compare(Vertex x, Vertex y)
    {
        int ret = x.value.CompareTo(y.value);
        if (ret != 0) return ret;

        ret = x.transfers.CompareTo(y.transfers);
        if (ret != 0) return ret;

        else return y.time.CompareTo(x.time);
    }
}