using System.Collections.Generic;

public class Vertex
{
    internal string name;
    internal Time time;
    internal List<Edge> incidentEdges;
    internal List<Vertex> neighbor;
    internal List<Edge> pointingToThis;
    
    internal int value; //for dijkstra's purpose
    internal Vertex parent; //for dijkstra's purpose
    internal Edge toParent; //for dijkstra's purpose

    public Vertex(string n, Time t)
    {
        name = n;
        time = t;
        incidentEdges = new List<Edge>();
        neighbor = new List<Vertex>();
        pointingToThis = new List<Edge>();
    }

    internal void addNeigbor(Vertex v, Edge e)
    {
        if (!neighbor.Contains(v))
        {
            neighbor.Add(v);
            incidentEdges.Add(e);
        }
    }

    /*
     * IN: name of the veretex and time
     * RET: true, if it is that vertex (with that name and time), otherwise false
     */
    public bool isThis(string name, Time time)
    {
        return (new VertecesComparator().Compare(this, new Vertex(name, time)) == 0);
    }

    override
    public string ToString()
    {
        return (name + " " + time.ToString());
    }

}