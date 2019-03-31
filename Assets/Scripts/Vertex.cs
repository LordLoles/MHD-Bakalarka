using System.Collections.Generic;

public class Vertex
{
    internal string name;
    internal Time time;
    internal bool loaded;
    
    internal int value; //for dijkstra's purpose
    internal int transfers; //for dijkstra's purpose
    internal Vertex parent; //for dijkstra's purpose
    internal Edge toParent; //for dijkstra's purpose
    internal List<Edge> alternate; //for dijkstra's purpose


    public Vertex(string n, Time t)
    {
        name = n;
        time = t;
        loaded = false;
        alternate = new List<Edge>();
    }


    /*
     * IN: name of the vertex and time
     * RET: true, if it is that vertex (with that name and time), otherwise false
     */
    public bool isThis(string name, Time time)
    {
        return (new VertecesComparator().Compare(this, new Vertex(name, time)) == 0);
    }

    /*
     * IN: vertex to compare
     * RET: true, if it is that vertex (with that name and time), otherwise false
     * When objects are different, but values are same, returns true
     */
    public bool isThis(Vertex v)
    {
        return isThis(v.name, v.time);
    }


    override
    public string ToString()
    {
        return (name + " " + time.ToString());
    }


    public void addAlternatePath(Edge e)
    {
        if (!alternate.Contains(e)) alternate.Add(e);
    }


}