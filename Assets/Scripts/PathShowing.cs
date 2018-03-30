using UnityEngine;
using System.Collections;

public class PathShowing : MonoBehaviour
{
    
    public void printThis(Vertex v)
    {
        //TODO odstranit cakacie hrany (a vrcholy medzi nimi)
        if (v.parent != null)
        {
        }
        if (v.parent != null)
        {
            Debug.Log("linkou: " + v.toParent.ToString());
        }
        Debug.Log("zastavka: " + v.name);
    }

}
