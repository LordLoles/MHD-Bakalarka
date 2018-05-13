using UnityEngine;
using System.Collections.Generic;

public class PathShowing : MonoBehaviour
{
    
    
    public void printPath(List<Edge> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            //vytvor panel
            
            //if (i==0) vytvor dve zastavky a hranu medzi
            //else hranu a zastavku
        }
    }

    public void printThis(Edge e)
    {
        Debug.Log(e.ToString());
    }


}
