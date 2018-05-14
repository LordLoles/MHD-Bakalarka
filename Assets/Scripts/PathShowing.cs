using UnityEngine;
using System.Collections.Generic;

public class PathShowing : MonoBehaviour
{
    public GameObject panelObj;
    public GameObject canvas;
    
    private int panelStep = -120;
    private int now = -170;
    private List<GameObject> panels;


    private void Start()
    {
        panels = new List<GameObject>();
        List<Edge> l = new List<Edge>();

        l.Add(new Edge("e", new Vertex("v1", new Time(0, 0)), new Vertex("v2", new Time(0, 5)), new Time(0, 0), new Time(0, 5)));
        printPath(l);
    }

    public void printPath(List<Edge> path)
    {
        GameObject panel = Instantiate(panelObj, canvas.transform);
        correctPanelPos(panel);
        panels.Add(panel);
        PanelManager panelManager = panel.GetComponent<PanelManager>();

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


}
