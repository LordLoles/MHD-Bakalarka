using System.Collections.Generic;

public class Graph
{
    internal List<Vertex> verteces;
    internal List<Edge> edges;

    internal SortedDictionary<string, List<Vertex>> allStops;

    internal Graph()
    {
        verteces = new List<Vertex>();
        edges = new List<Edge>();
        allStops = new SortedDictionary<string, List<Vertex>>();
    }

    /*
     * RET: List, where the verteces of this graph are deep-copied
     */
    internal List<Vertex> copyVerteces()
    {
        List<Vertex> target = new List<Vertex>();
        foreach (Vertex v in verteces) target.Add(v);
        return target;
    }

    /*
     * Adds vertex to verteces list and to allStops dictionary
     */
    internal void addVertex(Vertex v)
    {
        verteces.Add(v);
        if (!allStops.ContainsKey(v.name)) allStops.Add(v.name, new List<Vertex>());
        allStops[v.name].Add(v);
    }

    internal Vertex clostestAfterTimeByVertex(Time time, Vertex vertex)
    {
        return clostestAfterTimeByName(time, vertex.name);
    }

    internal Vertex clostestAfterTimeByName(Time time, string name)
    {
        List<Vertex> stops = allStops[name];
        stops.Sort(new VertecesComparator());
        foreach (Vertex v in stops)
        {
            if (time.hour <= v.time.hour && time.min <= v.time.min) return v;
        }
        throw new System.Exception("No vertex after that time");
    }

}
