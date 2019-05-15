using System.Collections.Generic;

public class Graph
{
    internal List<Vertex> verteces; //set
    internal List<Edge> edges;

    internal SortedDictionary<string, List<Vertex>> allStops;
    internal Dictionary<Vertex, List<Edge>> allEdges;
    internal Dictionary<Vertex, HashSet<Vertex>> neighbors;
    internal Dictionary<KeyValuePair<Vertex, int>, Edge> toThisVertex;

    internal int longestEdge;


    internal Graph()
    {
        verteces = new List<Vertex>();
        edges = new List<Edge>();
        allStops = new SortedDictionary<string, List<Vertex>>();
        allEdges = new Dictionary<Vertex, List<Edge>>();
        neighbors = new Dictionary<Vertex, HashSet<Vertex>>();
        toThisVertex = new Dictionary<KeyValuePair<Vertex, int>, Edge> ();
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
        KeyValuePair<Vertex, int> p = pair(to, e.linkID);
        if (!toThisVertex.ContainsKey(p)) toThisVertex.Add(p, e);
        allEdges[v].Add(e);
        neighbors[v].Add(to);
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


    private KeyValuePair<Vertex, int> pair(Vertex v, int id)
    {
        return new KeyValuePair<Vertex, int>(v, id);
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
     * Returns the edge with the same name as given edge 
     * starting in the vertex, that the given edge ends - succesor
     */
    public Edge getSuccesor(Edge e)
    {
        return e.successor;
    }


    /*
     * Returns the edge with the same name as given edge 
     * ending in the vertex, that the given edge starts - predecessor
     */
    public Edge getPredecessor(Edge e)
    {
        return e.predecessor;
    }


    /*
     * Returns the edge with the same name as given name
     * ending in the vertex, that is neighbor to given Vertex - predecessor
     */
    public Edge getPredecessor(int id, Vertex v)
    {
        return toThisVertex[pair(v, id)];
    }
}
