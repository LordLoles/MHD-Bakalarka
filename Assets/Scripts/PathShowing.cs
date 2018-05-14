using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PathShowing : MonoBehaviour
{
    public GameObject panelObj;
    public GameObject canvas;
    
    private int panelStep = -110;
    private int start = -160;
    private int now;
    private List<GameObject> panels;


    private void Awake()
    {
        panels = new List<GameObject>();
        now = start;
        /*
        List<Edge> l = new List<Edge>();
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        printPath(l);*/
    }

    public void printPath(List<Edge> path)
    {
        //foreach (Edge e in path) Debug.Log(e.ToString());

        GameObject panel = Instantiate(panelObj, canvas.transform);
        correctPanelPos(panel);
        panels.Add(panel);
        PanelManager panelManager = panel.GetComponent<PanelManager>();
        panelManager.onStart(panel.GetComponent<ScrollRect>());

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
        foreach (GameObject go in panels) GameObject.Destroy(go);
        now = start;
        panels = new List<GameObject>();
    }

}
