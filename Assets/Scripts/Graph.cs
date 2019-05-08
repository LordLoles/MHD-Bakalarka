using System.Collections.Generic;

public class Graph
{
    internal List<Vertex> verteces; //set
    internal List<Edge> edges;

    internal SortedDictionary<string, List<Vertex>> allStops;
    internal Dictionary<Vertex, List<Edge>> allEdges;
    internal Dictionary<Vertex, HashSet<Vertex>> neighbors;
    internal Dictionary<Vertex, HashSet<Edge>> toThisVertex;

    internal int longestEdge;


    internal Graph()
    {
        verteces = new List<Vertex>();
        edges = new List<Edge>();
        allStops = new SortedDictionary<string, List<Vertex>>();
        allEdges = new Dictionary<Vertex, List<Edge>>();
        neighbors = new Dictionary<Vertex, HashSet<Vertex>>();
        toThisVertex = new Dictionary<Vertex, HashSet<Edge>>();
        longestEdge = -1;
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
     * Adds edge to edges HashSet and to allEdges and neighbors dictionary
     */
    internal void addEdge(Edge e)
    {
        edges.Add(e);
        Vertex v = e.fromV;
        Vertex to = e.toV;
        if (!allEdges.ContainsKey(v)) allEdges.Add(v, new List<Edge>());
        if (!neighbors.ContainsKey(v)) neighbors.Add(v, new HashSet<Vertex>());
        if (!toThisVertex.ContainsKey(to)) toThisVertex.Add(to, new HashSet<Edge>());
        allEdges[v].Add(e);
        neighbors[v].Add(to);
        toThisVertex[to].Add(e);
        if (e.travellTime > longestEdge) longestEdge = e.travellTime;
    }


    internal Vertex clostestAfterTimeByVertex(Time time, Vertex vertex)
    {
        return clostestAfterTimeByName(time, vertex.name);
    }


    internal Vertex clostestAfterTimeByName(Time time, string name)
    {
        List<Vertex> stops = new List<Vertex>(allStops[name]);
        stops.Sort(new VertecesComparator());
        foreach (Vertex v in stops)
        {
            if (!(time.CompareTo(v.time) == 1)) return v;
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
        return new List<Vertex>(neighbors[from]);
    }


    /*
     * Returns list of edges from embedded vertex.
     */
    public List<Edge> getEdgesToVertex(Vertex to)
    {
        if (!toThisVertex.ContainsKey(to)) return new List<Edge>();
        return new List<Edge>(toThisVertex[to]);
    }


    /*
     * Returns the edge with the same name as given edge 
     * starting in the vertex, that the given edge ends - succesor
     */
    public Edge getSuccesor(Edge e)
    {
        string name = e.name;
        foreach (Edge next in getIncidentEdges(e.toV))
            if (next.name.Equals(name)) return next;
        return null;
    }


    /*
     * Returns the edge with the same name as given edge 
     * ending in the vertex, that the given edge starts - predecessor
     */
    public Edge getPredecessor(Edge e)
    {
        string name = e.name;
        foreach (Edge pred in getEdgesToVertex(e.toV))
            if (pred.name.Equals(name)) return pred;
        return null;
    }


    /*
     * Returns the edge with the same name as given name
     * ending in the vertex, that is neighbor to given Vertex - predecessor
     */
    public Edge getPredecessor(string name, Vertex v)
    {
        foreach (Edge pred in getEdgesToVertex(v))
            if (pred.name.Equals(name)) return pred;
        return null;
    }
}
