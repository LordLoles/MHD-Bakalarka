using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public GameObject zastavkaObj;
    public GameObject linkaObj;
    public GameObject scrollPanelObj;

    private GameObject scrollPanel;
    private int step = 100;
    private int now = 0;

    private void Awake()
    {
        scrollPanel = Instantiate(scrollPanelObj, transform) as GameObject;
    }

    public GameObject addStop(Vertex v)
    {
        GameObject go = Instantiate(zastavkaObj, scrollPanel.transform);
        correctPos(go);
        return go;
    }


    public GameObject addLink(Edge e)
    {
        GameObject go = Instantiate(linkaObj, scrollPanel.transform);
        correctPos(go);
        return go;
    }


    private void correctPos(GameObject go)
    {
        go.transform.localPosition = new Vector3(now, 0, 0);
        now += step;
    }

    public void correctNameTime(GameObject go)
    {
        
    }

}
