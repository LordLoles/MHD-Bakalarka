using System.Collections.Generic;

public class VertecesComparator : IComparer<Vertex>
{

    public int Compare(Vertex x, Vertex y)
    {
        if (x.name == y.name && x.time.ToString().Equals(y.time.ToString())) return 0; //x == y

        int ret;
        if ((ret = x.name.CompareTo(y.name)) != 0) return ret; //sorting by name

        //x_name == y_name

        if (x.time.hour > y.time.hour) return 1; //x > y
        if (x.time.hour < y.time.hour) return -1; //x < y

        //x_hour == y_hour

        if (x.time.min > y.time.min) return 1; //x > y

        return -1; // last possibility (equality excluded)
    }
}