using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra {

    private Graph graph;
    private Time now;
    private PathShowing pathShowing;
    private int amountNow = 0;
    private PathMaker pathMaker;


    public Dijkstra(Graph graph, PathMaker pm)
    {
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        pathShowing = init.GetComponent<PathShowing>();
        pathMaker = pm;
        pathShowing.pathMaker = pm;

        this.graph = graph;
        updateTime();
        updateVertecesValues();
    }


    private Vertex peek(List<Vertex> vs)
    {
        Vertex v = vs[0];
        vs.RemoveAt(0);
        return v;
    }


    private void DijkstrasAlgorhitm(Vertex start, string fin)
    {
        updateVertecesValues();

        Dictionary<Vertex, bool> visited = new Dictionary<Vertex, bool>();
        start.parent = null;
        start.value = 0;
        MinHeap<Vertex> inScope = new MinHeap<Vertex>(new DijkstrasComparator());
        inScope.Add(start);

        while (inScope.Count() > 0)
        {
            Vertex now = inScope.PopMin();
            
            if (graph.getNeighbors(now).Contains(start)) break;

            List<Vertex> neighbors = graph.getNeighbors(now);
            List<Edge> incidentEdges = graph.getIncidentEdges(now);

            if (!now.name.Equals(fin))
            {
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Vertex v = neighbors[i];
                    Edge e = incidentEdges[i];


                    if (visited.ContainsKey(v)) continue;

                    v.addAlternatePath(e);

                    int newValue = now.value + e.travellTime;
                    if (newValue < v.value)
                    {
                        v.value = newValue;
                        v.parent = now;
                        v.toParent = e;
                        inScope.Add(v);
                    }
                }
            }
            else
            {
                amountNow--;
                if (amountNow == 0) return;
            }
            visited.Add(now, true);
        }
    }


    private void printPathsForStop(string stop, int amount)
    {
        if (amount == 0) throw new System.Exception("This is how I print 0 stops!");

        int already = 0;
        List<Vertex> targets = graph.allStops[stop];

        foreach (Vertex v in targets)
        {
            if (v.value != int.MaxValue)
            {
                already++;
                //Debug.Log(already + ". moznost:");
                pathShowing.printPath(pathMaker.makePath(v));
                if (amount == already) return;
            }
        }

        if (already == 0) throw new System.Exception("No path to this stop was found.");
    }


    internal void shortestPathNow(string start, string fin)
    {
        shortestPathsAmountNow(start, fin, 1);
    }


    internal void shortestPath(Time time, string start, string fin)
    {
        shortestPathsAmount(time, start, fin, 1);
    }


    internal void shortestPathsAmountNow(string start, string fin, int amount)
    {
        updateTime();
        shortestPathsAmount(now, start, fin, amount);
    }


    internal void shortestPathsAmount(Time time, string start, string fin, int amount)
    {
        amountNow = amount;
        DijkstrasAlgorhitm(graph.clostestAfterTimeByName(time, start), fin);
        printPathsForStop(fin, amount);
    }


    internal void updateTime()
    {
        now = new Time(System.DateTime.Now.Hour, System.DateTime.Now.Minute);
    }


    private void updateVertecesValues()
    {
        foreach (Vertex v in graph.verteces)
        {
            v.value = int.MaxValue;
            v.parent = null;
            v.toParent = null;
        }
        pathShowing.flush();
    }

}
