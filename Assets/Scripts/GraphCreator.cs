using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GraphCreator {
    
    private Graph graph;

    private string[] stops;
    private string[] lines;

    public GraphCreator(string path, string stopsFile, string linesFile)
    {
        stops = System.IO.File.ReadAllLines(path + stopsFile + ".txt");
        lines = System.IO.File.ReadAllLines(path + linesFile + ".txt");
        Debug.Log("pocet liniek1 = " + lines.Length / 5);

        this.graph = new Graph(new List<Vertex>(), new List<Edge>());
    }

    private Vertex findVertex(string name)
    {
        foreach (Vertex v in graph.verteces)
        {
            if (v.name == name) return v;
        }
        throw new Exception("No such vertex:" + name);
    }

    private Vertex findVertexByWords(string[] words, int fromIndex)
    {
        string name = "";
        for (int i=fromIndex; i < words.Length; i++)
        {
            if (i != fromIndex) name += " ";
            name += words[i];
        }
        return findVertex(name);
    }

    private void makeEdges(string name, string line1, string line2)
    {
        string[] distAndStops = line1.Split(new string[] { " | " }, StringSplitOptions.None);
        string[] times = line2.Split(' ');
        foreach (string time in times)
        {
            Time origin = Time.makeTime(time);
            for (int j = 0; j < distAndStops.Length - 1; j++)
            {
                string[] distAndStopFrom = distAndStops[j].Split(' ');
                string[] distAndStopTo = distAndStops[j+1].Split(' ');

                Time fromT = Time.addToTime(origin, int.Parse(distAndStopFrom[0]));
                Time toT = Time.addToTime(origin, int.Parse(distAndStopTo[0]));
                Vertex fromV = findVertexByWords(distAndStopFrom, 1);
                Vertex toV = findVertexByWords(distAndStopTo, 1);

                graph.edges.Add(new Edge(name, fromV, toV, fromT, toT));
            }
        }
    }

    public void makeGraph()
    {
        // Make verteces
        foreach (string s in stops){
            graph.verteces.Add(new Vertex(s));
        }
        Debug.Log("pocet zastavok = " + graph.verteces.Count);
        // Make edges
        int i = 0;
        while (i < lines.Length)
        {
            string name = lines[i];
            makeEdges(name, lines[i + 1], lines[i + 2]);
            makeEdges(name, lines[i + 3], lines[i + 4]);
            i += 5;
        }
        Debug.Log("pocet liniek2 = " + graph.edges.Count);
    }

    /*
     * RET: Graph type of the current graph,
     * that contains list of verteces anf list of edges
     */
    public Graph getGraph()
    {
        return this.graph;
    }
	
}
