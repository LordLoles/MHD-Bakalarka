using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Init : MonoBehaviour
{

    private Graph graph;
    private Dijkstra dijkstra;

    //public string path = @"C:\Users\alojz\Documents\UnityProjects\MHD\Assets\Bratislava\";
    public string stopsFile;
    public string linesFile;
    public string city;


    void Start()
    {
        //Debug.Log(Application.dataPath);
        GraphCreator gc = new GraphCreator(Application.dataPath + "/Data/" + city + "/", stopsFile, linesFile);
        gc.makeGraph();
        graph = gc.getGraph();

        dijkstra = new Dijkstra(graph);

        //gc.printGraph();

    }


    public void startSearching(string start, string fin)
    {
        Debug.Log("spustam dijkstru z " + start + " do " + fin);
        dijkstra.shortestPathsAmount(new Time(0, 0), start, fin, 10);
    }
    

}
