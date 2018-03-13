using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Init : MonoBehaviour
{

    private Graph graph;

    //public string path = @"C:\Users\alojz\Documents\UnityProjects\MHD\Assets\Bratislava\";
    public string stopsFile = "zastavky";
    public string linesFile = "linky";
    public string city = "Bratislava";

    void Start()
    {
        //Debug.Log(Application.dataPath);
        GraphCreator gc = new GraphCreator(Application.dataPath + "/" + city + "/", stopsFile, linesFile);
        gc.makeGraph();
        this.graph = gc.getGraph();
    }
    
}
