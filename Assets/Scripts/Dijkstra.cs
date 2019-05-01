using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra {

    private Graph graph;
    private Time now;
    private PathShowing pathShowing;
    private int amountNow = 0;
    private PathMaker pathMaker;
    private GraphCreator gc;


    public Dijkstra(Graph graph, PathMaker pm, GraphCreator gc)
    {
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        pathShowing = init.GetComponent<PathShowing>();
        pathMaker = pm;
        pathShowing.pathMaker = pm;

        this.gc = gc;
        this.graph = graph;
        updateTime();
        resetVertecesValues();
    }


    private void updateVertexNoAdd(Vertex target, Edge toTarget, int newValue, int transfers, Vertex pathStart, int sections)
    {
        target.value = newValue;
        target.transfers = transfers;
        target.parent = toTarget.fromV;
        target.toParent = toTarget;
        target.pathStart = pathStart;
        target.sections = sections;
    }
    

    private void updateVertex(Vertex target, Edge toTarget, int newValue, int transfers, MinHeap<Vertex> inScope, Vertex pathStart, int sections)
    {
        updateVertexNoAdd(target, toTarget, newValue, transfers, pathStart, sections);
        inScope.Add(target);
    }


    private void DijkstrasAlgorhitm(Vertex start, string fin)
    {
        resetVertecesValues();

        startVertexSettings(start);

        Dictionary<Vertex, bool> visited = new Dictionary<Vertex, bool>();
        DijkstrasComparator dc = new DijkstrasComparator();
        MinHeap<Vertex> inScope = new MinHeap<Vertex>(dc);
        inScope.Add(start);

        while (inScope.Count() > 0)
        {
            Vertex now = inScope.PopMin();

            List<Vertex> neighbors = graph.getNeighbors(now);
            List<Edge> incidentEdges = graph.getIncidentEdges(now);

            if (now.name.Equals(start.name) && now != start)
            {
                updateVertexNoAdd(now, now.lastWaiting, now.value, 0, now, 0);
            }

            if (!now.name.Equals(fin))
            {
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Vertex v = neighbors[i];
                    Edge e = incidentEdges[i];

                    while (gc.needToLoad(v.time))
                    {
                        gc.nextLoad();
                    }
                    if (e.waitingEdge) e.toV.lastWaiting = e;
                    if (v.isThis(start)) break;
                    if (visited.ContainsKey(v)) continue;

                    v.addAlternatePath(e);

                    int newValue = now.value + e.travellTime;

                    bool incTransfers = ((now.toParent == null) || (!now.toParent.name.Equals(e.name))) 
                        && (!e.waitingEdge);

                    int newTransfers = now.transfers;
                    //if (incTransfers) newTransfers++;
                    
                    int newSections = e.waitingEdge ? now.sections : (now.sections + 1);

                    if ((newValue < v.value) 
                        || ((newValue == v.value) && (newTransfers < v.transfers)) 
                        || ((newValue == v.value) && (newTransfers == v.transfers) && (v.parent.pathStart.time.CompareTo(v.pathStart.time) == 1))
                        || ((newValue == v.value) && (newTransfers == v.transfers) && (v.parent.pathStart.time.CompareTo(v.pathStart.time) == 0) && (v.sections > newSections))
                        )
                            //updateVertex(v, e, newValue, newTransfers, inScope, now.pathStart, newSections);
                            updateVertex(v, e, newValue, 0, inScope, now.pathStart, newSections);
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
        List<Vertex> targets = new List<Vertex>(graph.allStops[stop]);
        targets.Sort(new DijkstrasComparator());

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


    private void reversedDijkstrasAlgorhitm(string start, string fin)
    {
        List<Vertex> targets = new List<Vertex>(graph.allStops[fin]);
        DijkstrasComparator dc = new DijkstrasComparator();
        targets.Sort(dc);

        foreach (Vertex startV in targets)
        {
            if (startV.value == int.MaxValue) break;

            MinHeap<Vertex> inScope = new MinHeap<Vertex>(dc);
            inScope.Add(startV);


            while (inScope.Count() > 0)
            {
                Vertex now = inScope.PopMin();

                List<Edge> edgesToVertexNow = graph.getEdgesToVertex(now);

                if (now.name.Equals(start)) break;

                for (int i = 0; i < edgesToVertexNow.Count; i++)
                {
                    Edge e = edgesToVertexNow[i];
                    Vertex v = e.fromV;


                }

            }

        }
        
    }


    internal void updateTime()
    {
        now = new Time(System.DateTime.Now.Hour, System.DateTime.Now.Minute);
    }


    private void startVertexSettings(Vertex start)
    {
        start.parent = null;
        start.value = 0;
        start.pathStart = start;
        start.sections = 0;
        //start.lastWaiting = new Edge(start.name, start, start, start.time, start.time);
        //start.lastWaiting.setThisWaiting();
    }


    private void resetVertecesValues()
    {
        foreach (Vertex v in graph.verteces)
        {
            v.value = int.MaxValue;
            v.transfers = 0;
            v.parent = null;
            v.toParent = null;
            v.pathStart = null;
            v.lastWaiting = null;
            v.sections = int.MaxValue;
        }
        pathShowing.flush();
    }

}
