
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



public class Edge
{
    internal string name;
    internal Vertex fromV;
    internal Vertex toV;
    internal int travellTime; //minutes


    public Edge(string name, Vertex fromV, Vertex toV, int travellTime)
    {
        this.name = name;
        this.fromV = fromV;
        this.toV = toV;
        this.travellTime = travellTime;
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
