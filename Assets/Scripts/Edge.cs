public class Edge
{
    internal string name;
    internal Vertex fromV;
    internal Vertex toV;
    internal Time fromT;
    internal Time toT;
    internal int travellTime; //minutes
    internal bool waitingEdge; //determines whether is this edge from vertex to the same named vertex (waiting on stop)

    internal bool linkScanDone; //for dijkstra's purpose


    public Edge(string name, Vertex fromV, Vertex toV, Time fromT, Time toT)
    {
        this.name = name;
        this.fromV = fromV;
        this.toV = toV;
        this.fromT = fromT;
        this.toT = toT;
        travellTime = Time.differenceBetweenTimesMin(this.fromT, this.toT);
        waitingEdge = false;
        linkScanDone = false;
    }


    internal void setThisWaiting()
    {
        waitingEdge = true;
    }

    /*
     * IN: two (incident) edges.
     * Returns null, if given edges are not incident.
     * Else returns edge with name of the second given 
     * edge connecting the starting vertex of first edge 
     * with the ending vertex of the second edge.
     */
    public static Edge combineIncidentEdges(Edge e, Edge f)
    {
        if (!e.toV.isThis(f.fromV)) return null;
        return new Edge(f.name + " comb", e.fromV, f.toV, e.fromT, f.toT);
    }


    override
    public string ToString()
    {
        return (name + " (" + fromV.ToString() + ") (" + toV.ToString() + ") ");
    }


}