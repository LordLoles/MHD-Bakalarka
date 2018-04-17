using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Security.Permissions;

public class Init : MonoBehaviour
{

    private Graph graph;
    private Dijkstra dijkstra;
    private GraphCreator gc;
    private Thread thread;

    //public string path = @"C:\Users\alojz\Documents\UnityProjects\MHD\Assets\Bratislava\";
    public string stopsFile;
    public string linesFile;
    public string city;


    void Start()
    {
        //Debug.Log(Application.dataPath);
        gc = new GraphCreator(Application.dataPath + "/Data/" + city + "/", stopsFile, linesFile);

        thread = new Thread(gc.makeGraph);
        thread.Priority = System.Threading.ThreadPriority.Highest;
        
        thread.Start();

        //gc.makeGraph();

        graph = gc.getGraph();

        dijkstra = new Dijkstra(graph);

    }


    public void startSearching(string start, string fin)
    {
        if (gc.loaded == 100)
        {
            Debug.Log("spustam dijkstru z " + start + " do " + fin);
            dijkstra.shortestPathsAmount(new Time(0, 0), start, fin, 10);
        }
        else
        {
            Debug.Log("mam " + gc.loaded + "%");
        }
    }


    [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
    public void OnApplicationQuit()
    {
        thread.Abort();
    }


}
