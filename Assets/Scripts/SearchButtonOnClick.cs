using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchButtonOnClick : MonoBehaviour
{

    public Text start;
    public Text fin;

    public void OnClick()
    {
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        Init initScript = init.GetComponent<Init>();
        initScript.startSearching(start.text, fin.text);
    }


}
