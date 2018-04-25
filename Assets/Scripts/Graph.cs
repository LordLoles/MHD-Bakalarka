using System.Collections.Generic;

public class Graph
{
    internal List<Vertex> verteces; //set
    internal List<Edge> edges;

    internal SortedDictionary<string, List<Vertex>> allStops;
    internal Dictionary<Vertex, List<Edge>> allEdges;
    internal Dictionary<Vertex, List<Vertex>> neighbors;


    internal Graph()
    {
        verteces = new List<Vertex>();
        edges = new List<Edge>();
        allStops = new SortedDictionary<string, List<Vertex>>();
        allEdges = new Dictionary<Vertex, List<Edge>>();
        neighbors = new Dictionary<Vertex, List<Vertex>>();
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


    /*
     * Adds edge to edges list and to allEdges and neighbors dictionary
     */
    internal void addEdge(Edge e)
    {
        edges.Add(e);
        Vertex v = e.fromV;
        if (!allEdges.ContainsKey(v)) allEdges.Add(v, new List<Edge>());
        if (!neighbors.ContainsKey(v)) neighbors.Add(v, new List<Vertex>());
        allEdges[v].Add(e);
        neighbors[v].Add(e.toV);
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


    /*
     * Returns list of incident edges to embedded vertex
     */
    public List<Edge> getIncidentEdges(Vertex from)
    {
        if (!allEdges.ContainsKey(from)) return new List<Edge>();
        return allEdges[from];
    }


    /*
     * Returns list of neighbors to embedded vertex
     */
    public List<Vertex> getNeighbors(Vertex from)
    {
        /*
        List<Vertex> list = new List<Vertex>();
        foreach (Edge e in getIncidentEdges(from)) list.Add(e.toV);
        return list;
        */
        if (!neighbors.ContainsKey(from)) return new List<Vertex>();
        return neighbors[from];
    }


}
