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
    //private Thread thread;
    private PathMaker pathMaker;
    private PathShowing pathShowing;
    private DataBaseChange dbc;

    //public string path = @"C:\Users\alojz\Documents\UnityProjects\MHD\Assets\Bratislava\";
    public string stopsFile;
    public string linesFile;
    public string city;
    public Text nacitavam;
    public Text chybaTxt;


    void Start()
    {
        Screen.SetResolution(800, 860, false);

        myStart();
    }


    public void myStart()
    {
        //Debug.Log(Application.dataPath);

        /*
        thread = new Thread(gc.makeGraph);
        thread.Priority = System.Threading.ThreadPriority.Highest;

        thread.Start();*/

        //gc.makeGraph();

        pathShowing = gameObject.GetComponent<PathShowing>();

        dbc = gameObject.GetComponent<DataBaseChange>();
        dbc.stopsFile = stopsFile;
        dbc.cityName.text = city;
        dbc.inputField.gameObject.SetActive(false);

        ErrorHandler.chybaTxt = chybaTxt;
        ErrorHandler.hide();
    }

    /*
    public void Update()
    {
        if (gc.loaded < 100)
        {
            nacitavam.enabled = true;
            nacitavam.text = "Načítavam \n" + gc.loaded.ToString() + " %";
        }
        else nacitavam.enabled = false;
    }*/


    public void startSearching(string start, string fin, Time time, int amount)
    {
        /*
        if (gc.loaded == 100)
        {
            pathShowing.nextSearch();
            Debug.Log("spustam dijkstru z " + start + " do " + fin);
            pathShowing.setAmountOfPaths(amount);
            dijkstra.shortestPathsAmount(time, start, fin, amount);
        }
        else
        {
            Debug.Log("mam " + gc.loaded + "%");
        }*/

        long t1 = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;

        gc = new GraphCreator(Application.dataPath + "/Data/" + city + "/", stopsFile, linesFile);

        gc.makeGraphOneLoadSooner(time);
        gc.nextLoad();
        //gc.makeGraph(time);

        graph = gc.getGraph();
        pathMaker = new PathMaker(graph);
        dijkstra = new Dijkstra(graph, pathMaker, gc);

        pathShowing.nextSearch();
        pathShowing.setAmountOfPaths(amount);

        int i = 0;
        int tries = 3;
        while (!graph.allStops.ContainsKey(start) || !graph.allStops.ContainsKey(fin))
        {
            i++;
            gc.nextLoad();
            if (i == tries)
            {
                if (!graph.allStops.ContainsKey(start))
                    ErrorHandler.printErrorMsg("Nenašla sa počiatočná zastávka.\n Skontrulujte preklepy.");

                if (!graph.allStops.ContainsKey(fin))
                    ErrorHandler.printErrorMsg("Nenašla sa kocová zastávka.\n Skontrulujte preklepy.");
            }
        }

        Debug.Log("spustam dijkstru z " + start + " do " + fin);
        dijkstra.shortestPathsAmount(time, start, fin, amount);
        
        long t2 = (long)(System.DateTime.Now - new System.DateTime(1970, 1, 1)).TotalMilliseconds;
        Debug.Log("Cas behu: " + (t2 - t1).ToString());
    }

    /*
    [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
    public void OnApplicationQuit()
    {
        try
        {
            thread.Abort();
        }
        catch (Exception e) { }
    }*/


}
