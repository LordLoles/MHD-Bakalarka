using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GraphCreator{

    private Graph graph;

    private string[] stops;
    private string[] lines;

    public int loaded = 0;
    
    private int minsToLoad = 35;
    private int maxLoads;
    private int nowLoads = 0;
    private Time lastlyLoaded;

    private int linkIDNow = 0;


    public GraphCreator(string path, string stopsFile, string linesFile)
    {
        stops = System.IO.File.ReadAllLines(path + stopsFile + ".txt");
        lines = System.IO.File.ReadAllLines(path + linesFile + ".txt");

        maxLoads = (int)Math.Floor((Time.minsInDay - 1) * 1.0 / minsToLoad);
        this.graph = new Graph();
    }


    private String makeName(string[] words, int fromIndex)
    {
        string name = "";
        for (int i = fromIndex; i < words.Length; i++)
        {
            if (i != fromIndex) name += " ";
            name += words[i];
        }
        return name;
    }


    private Vertex findVertex(string name, Time time)
    {
        List<Vertex> list = graph.allStops[name];
        foreach (Vertex v in graph.allStops[name]) if (time.isThis(v.time)) return v;
        throw new Exception("No such vertex: " + name);
    }


    private Vertex findVertexByWords(string[] words, int fromIndex, Time time)
    {
        string name = makeName(words, fromIndex);
        return findVertex(name, time);
    }


    private bool existVertex(string[] words, int fromIndex, Time time)
    {
        string name = makeName(words, fromIndex);
        if (!graph.allStops.ContainsKey(name)) return false;
        foreach (Vertex v in graph.allStops[name]) if (time.isThis(v.time)) return true;
        return false;
    }


    private Vertex makeVertexByWords(string[] words, int fromIndex, Time time)
    {
        string name = makeName(words, fromIndex);
        return new Vertex(name, time);
    }


    private Vertex getVertex(string[] words, int fromIndex, Time time)
    {
        Vertex v;
        if (existVertex(words, fromIndex, time))
        {
            v = findVertexByWords(words, 1, time);
        }
        else
        {
            v = makeVertexByWords(words, 1, time);
            graph.addVertex(v);
        }
        return v;
    }


    private void makeVAndE(string name, string line1, string line2, Time fromTime)
    {
        if (line1.Equals("")) return;

        string[] distAndStops = line1.Split(new string[] {" | "}, StringSplitOptions.None);
        string[] times = line2.Split(' ');
        Time endTime = Time.addToTime(fromTime, minsToLoad);

        foreach (string time in times)
        {
            
            Time origin = Time.makeTime(time);

            if (!origin.isBetween(fromTime, endTime)) continue;

            Edge previous = null;
            linkIDNow++;

            for (int j = 0; j < distAndStops.Length - 1; j++)
            {
                string[] distAndStopFrom = distAndStops[j].Split(' ');
                string[] distAndStopTo = distAndStops[j+1].Split(' ');
                
                Time fromT = Time.addToTime(origin, int.Parse(distAndStopFrom[0]));
                Time toT = Time.addToTime(origin, int.Parse(distAndStopTo[0]));
                
                Vertex fromV = getVertex(distAndStopFrom, 1, fromT);
                Vertex toV = getVertex(distAndStopTo, 1, toT);

                /*
                Vertex fromV = makeVertexByWords(distAndStopFrom, 1, fromT);
                Vertex toV = makeVertexByWords(distAndStopTo, 1, toT);
                graph.addVertex(fromV);
                graph.addVertex(toV);
                */

                Edge e = new Edge(name, fromV, toV, fromT, toT);

                e.linkID = linkIDNow;
                e.predecessor = previous;
                if (previous != null) previous.successor = e;
                previous = e;

                graph.addEdge(e);
                //fromV.loaded = true;
            }
        }
    }


    private void makeWaitingEdges(Time fromTime)
    {
        int tillNow = 0;
        int all = graph.allStops.Count;
        Time endTime = Time.addToTime(fromTime, minsToLoad);

        foreach (KeyValuePair<string, List<Vertex>> pair in graph.allStops)
        { 
            List<Vertex> list = pair.Value;
            Edge previous = null;
            linkIDNow++;

            loaded = (int)(50 + ((100 * (float)tillNow / all) / 2));
            tillNow++;

            list.Sort(new VertecesComparator());
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count-1) continue;
                Vertex fromV = list[i];
                Vertex toV = list[i + 1];
                if (!fromV.time.isBetween(fromTime, endTime)) continue;

                Edge e = new Edge(pair.Key, fromV, toV, fromV.time, toV.time);
                e.linkID = linkIDNow;
                e.setThisWaiting();
                e.predecessor = previous;
                if (previous != null) previous.successor = e;
                previous = e;

                graph.addEdge(e);
            }
        }
    }

    /*
     * IN: Time to check
     * RET: True, if (stop with) that time has chance to be not fully loaded
     */
    public bool needToLoad(Time t)
    {
        int finMins = lastlyLoaded.toMinutes();
        if (t.CompareTo(lastlyLoaded) == 1) finMins += Time.minsInDay;
        return t.toMinutes() + graph.longestEdge >= finMins;
            //t.addToTime(graph.longestEdge).CompareTo(lastlyLoaded) == 1;
    }


    public void nextLoad()
    {
        //Debug.Log("Next Load");
        makeGraph(lastlyLoaded);
    }


    public void makeGraphOneLoadSooner(Time fromTime)
    {
        makeGraph(fromTime.subtractFromTime(minsToLoad));
    }


    public void makeGraph(Time fromTime)
    {
        nowLoads++;
        if (nowLoads > maxLoads) return;

        int i = 0;
        while (i < lines.Length)
        {
            loaded = (int)((100 * ((float)i / lines.Length)) / 2);

            string name = lines[i];
            makeVAndE(name, lines[i + 1], lines[i + 2], fromTime);
            makeVAndE(name, lines[i + 3], lines[i + 4], fromTime);
            i += 5;
        }
        
        makeWaitingEdges(fromTime);
        loaded = 100;

        lastlyLoaded = Time.addToTime(fromTime, minsToLoad);
        //printAmounts();
        //printGraph();
    }


    /*
     * RET: Graph (type) of the current graph,
     * that contains list of verteces and list of edges
     */
    public Graph getGraph()
    {
        return this.graph;
    }


    /*
     * Debugging tool
     */
    public void printAmounts()
    {
        Debug.Log("pocet liniek = " + lines.Length / 5);
        Debug.Log("pocet zastavok = " + graph.allStops.Count);
        Debug.Log("pocet vrcholov grafu = " + graph.verteces.Count);
        Debug.Log("pocet hran grafu = " + graph.edges.Count);
    }


    /*
     * Debugging tool
     */
    public void printGraph()
    {  
        Debug.Log("Vrcholy:");
        foreach (Vertex v in graph.verteces) Debug.Log(v.ToString());
        Debug.Log("Hrany:");
        foreach (Edge e in graph.edges) Debug.Log(e.ToString());
    }


}
