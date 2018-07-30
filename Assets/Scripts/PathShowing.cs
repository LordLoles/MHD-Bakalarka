using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PathShowing : MonoBehaviour
{
    public GameObject panelObj;
    public GameObject canvas;
    
    private int panelStep = -120;
    private int start = -170;
    private int now;
    private List<GameObject> panels;
    private int amount;

    internal PathMaker pathMaker;

    //Memento
    internal State state;
    internal PathsMemory pathsMemory; //caretaker


    private void Awake()
    {
        nextSearch();
        /*
        List<Edge> l = new List<Edge>();
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        printPath(l);
        flush();
        printPath(l);*/
    }

    public void printPath(List<Edge> path)
    {
        //foreach (Edge e in path) Debug.Log(e.ToString());
        state.paths.Add(path);

        GameObject panel = Instantiate(panelObj, canvas.transform);
        correctPanelPos(panel);
        panels.Add(panel);
        PanelManager panelManager = panel.GetComponent<PanelManager>();
        panelManager.onStart(panel.GetComponent<ScrollRect>(), this);

        for (int i = 0; i < path.Count; i++)
        {
            Edge e = path[i];

            if (i == 0)
            {
                panelManager.addStop(e.fromV);
                panelManager.addLink(e);
                panelManager.addStop(e.toV);
            }
            else
            {
                panelManager.addLink(e);
                panelManager.addStop(e.toV);
            }
        }
    }

    public void printThis(Edge e)
    {
        Debug.Log(e.ToString());
    }
    

    private void correctPanelPos(GameObject go)
    {
        go.transform.localPosition = new Vector3(0, now, 0);
        now += panelStep;
    }


    public void flush()
    {
        if (panels != null) foreach (GameObject go in panels) GameObject.Destroy(go);
        now = start;
        state = new State();
        panels = new List<GameObject>();
    }


    public void nextSearch()
    {
        flush();
        pathsMemory = new PathsMemory(this);
        panels = new List<GameObject>();
        now = start;
    }


    public void showAlternativePath(Vertex v)
    {
        Debug.Log("show alternative to " + v.ToString());
        memorizeThis();
        flush();

        int i = 0;

        List<List<Edge>> altAll = new List<List<Edge>>();

        foreach (Edge e in v.alternate)
        {
            if (i == amount) break;
            List<Edge> path = pathMaker.makePath(e.fromV);
            path.Add(e);
            altAll.Add(path);
            i++;
        }

        altAll.Sort(new AltPathComparator());

        foreach (List<Edge> path in altAll)
        {
            printPath(path);
        }

    }


    public void setPathMaker(PathMaker pm)
    {
        pathMaker = pm;
    }


    public void memorizeThis()
    {
        pathsMemory.memorize(state);
    }


    public void redoLastState()
    {
        State lastState = pathsMemory.getLastState();
        flush();
        foreach (List<Edge> path in lastState.paths) printPath(path);
    }


    public void setAmountOfPaths(int amount) { this.amount = amount; }

}
