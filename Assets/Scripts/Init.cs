using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Security.Permissions;
using UnityEngine.UI;

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
    public Text nacitavam;


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


    public void Update()
    {
        if (gc.loaded < 100) nacitavam.text = "Nacitavam \n" + gc.loaded.ToString() + " %";
        else nacitavam.enabled = false;
    }


    public void startSearching(string start, string fin, Time time, int amount)
    {
        if (gc.loaded == 100)
        {
            Debug.Log("spustam dijkstru z " + start + " do " + fin);
            dijkstra.shortestPathsAmount(time, start, fin, amount);
        }
        else
        {
            Debug.Log("mam " + gc.loaded + "%");
        }
    }


    [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
    public void OnApplicationQuit()
    {
        try
        {
            thread.Abort();
        }
        catch (Exception e) { }
    }


}
