internal class Edge
{
    internal string name;
    internal Vertex fromV;
    internal Vertex toV;
    internal Time fromT;
    internal Time toT;
    internal int travellTime; //minutes

    public Edge(string name, Vertex fromV, Vertex toV, Time fromT, Time toT)
    {
        this.name = name;
        this.fromV = fromV;
        this.toV = toV;
        this.fromT = fromT;
        this.toT = toT;
        this.travellTime = Time.differenceBetweenTimesMin(this.fromT, this.toT);
    }
}