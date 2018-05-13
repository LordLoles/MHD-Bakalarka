
public class Vertex
{
    internal string name;
    
    internal int value; //for dijkstra's purpose
    internal Vertex parent; //for dijkstra's purpose
    internal Edge toParent; //for dijkstra's purpose


    public Vertex(string n)
    {
        name = n;
    }
}

public class Time { }


public class Edge
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


public class Graph
{
    internal List<Vertex> verteces;
    internal List<Edge> edges;


    internal Graph()
    {
        verteces = new List<Vertex>();
        edges = new List<Edge>();
    }

}


public class Vertex
{
    internal string name;
    internal Time time;

    internal int value; //for dijkstra's purpose
    internal Vertex parent; //for dijkstra's purpose
    internal Edge toParent; //for dijkstra's purpose


    public Vertex(string n, Time t)
    {
        name = n;
        time = t;
    }
}
