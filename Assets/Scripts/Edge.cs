public class Edge
{
    internal string name;
    internal Vertex fromV;
    internal Vertex toV;
    internal Time fromT;
    internal Time toT;
    internal int travellTime; //minutes
    internal bool waitingEdge; //determines whether this edge is from vertex to the same vertex (waiting on stop)

    public Edge(string name, Vertex fromV, Vertex toV, Time fromT, Time toT)
    {
        this.name = name;
        this.fromV = fromV;
        this.toV = toV;
        this.fromT = fromT;
        this.toT = toT;
        this.travellTime = Time.differenceBetweenTimesMin(this.fromT, this.toT);
        waitingEdge = false;

        fromV.addNeigbor(toV, this);
        toV.pointingToThis.Add(this);
    }

    internal void setThisWaiting()
    {
        waitingEdge = true;
    }

    override
    public string ToString()
    {
        return (name + " (" + fromV.ToString() + ") (" + toV.ToString() + ") ");
    }

}