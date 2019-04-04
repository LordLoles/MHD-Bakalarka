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
    private PathMaker pathMaker;
    private PathShowing pathShowing;
    private DataBaseChange dbc;

    //public string path = @"C:\Users\alojz\Documents\UnityProjects\MHD\Assets\Bratislava\";
    public string stopsFile;
    public string linesFile;
    public string city;
    public Text nacitavam;


    void Start()
    {
        Screen.SetResolution(800, 860, false);

        myStart();
    }


    public void myStart()
    {
        //Debug.Log(Application.dataPath);
        gc = new GraphCreator(Application.dataPath + "/Data/" + city + "/", stopsFile, linesFile);

        /*
        thread = new Thread(gc.makeGraph);
        thread.Priority = System.Threading.ThreadPriority.Highest;

        thread.Start();*/

        //gc.makeGraph();

        graph = gc.getGraph();

        pathMaker = new PathMaker(graph);
        pathShowing = gameObject.GetComponent<PathShowing>();
        dbc = gameObject.GetComponent<DataBaseChange>();
        dbc.stopsFile = stopsFile;
        dbc.cityName.text = city;
        dbc.inputField.gameObject.SetActive(false);

        dijkstra = new Dijkstra(graph, pathMaker, gc);
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

        pathShowing.nextSearch();
        Debug.Log("spustam dijkstru z " + start + " do " + fin);
        pathShowing.setAmountOfPaths(amount);
        gc.makeGraph(time);
        dijkstra.shortestPathsAmount(time, start, fin, amount);
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
