using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    public GameObject zastavkaObj;
    public GameObject linkaObj;
    public GameObject scrollPanelObj;

    internal PathShowing pathShowing;

    private GameObject scrollPanel;
    private int step = 105;
    private int now = 0;

    public void onStart(ScrollRect sr, PathShowing ps)
    {
        pathShowing = ps;
        scrollPanel = Instantiate(scrollPanelObj, transform) as GameObject;
        sr.content = scrollPanel.GetComponent<RectTransform>();
    }

    public GameObject addStop(Vertex v)
    {
        GameObject go = Instantiate(zastavkaObj, scrollPanel.transform);
        correctPos(go);

        Text[] children = go.GetComponentsInChildren<Text>();
        children[0].text = v.name;
        children[1].text = v.time.ToString();

        Button btn = go.GetComponentInChildren<Button>();
        btn.GetComponent<StopObjectHolder>().zastavka = v;
        btn.GetComponent<StopObjectHolder>().panelManager = this;
        btn.GetComponentInChildren<Text>().text = "cesty sem " + v.alternate.Count;

        return go;
    }


    public GameObject addLink(Edge e)
    {
        GameObject go = Instantiate(linkaObj, scrollPanel.transform);
        correctPos(go);

        Text[] children = go.GetComponentsInChildren<Text>();
        if (e.waitingEdge)
        {
            children[0].text = "čakať";
            children[1].text = "";
        }
        else
        {
            children[0].text = "linka \'" + e.name + "\'";
            children[1].text = e.travellTime.ToString() + " min.";
        }

        return go;
    }


    private void correctPos(GameObject go)
    {
        go.transform.localPosition = new Vector3(now, 0, 0);
        now += step;
    }

}
