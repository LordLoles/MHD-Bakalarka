using System.Collections.Generic;

public class Vertex
{
    internal string name;
    internal Time time;
    
    internal int value; //for dijkstra's purpose
    internal Vertex parent; //for dijkstra's purpose
    internal Edge toParent; //for dijkstra's purpose
    internal HashSet<Edge> alternate; //for dijkstra's purpose
    internal Vertex pathStart; //for dijkstra's purpose
    internal Edge lastWaiting; //for dijkstra's purpose
    internal int transfers; //for dijkstra's purpose
    internal int sections; //for dijkstra's purpose
    internal Vertex linkStarting; //for dijkstra's purpose
    internal Edge toLinkStarting; //for dijkstra's purpose


    public Vertex(string n, Time t)
    {
        name = n;
        time = t;
        //loaded = false;

        value = int.MaxValue;
        parent = null;
        toParent = null;
        alternate = new HashSet<Edge>();
        pathStart = null;
        lastWaiting = null;
        sections = int.MaxValue;
        transfers = int.MaxValue;
        linkStarting = null;
        toLinkStarting = null;
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