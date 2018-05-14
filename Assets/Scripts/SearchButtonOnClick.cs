using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SearchButtonOnClick : MonoBehaviour
{

    public Text start;
    public Text fin;
    public Text time;

    public void OnClick()
    {
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        Init initScript = init.GetComponent<Init>();
        initScript.startSearching(start.text, fin.text, getTime(), 3);
    }

    private Time getTime()
    {
        try
        {
            string[] input = time.text.Split(':');
            return new Time(Int32.Parse(input[0]), Int32.Parse(input[1]));
        }
        catch(Exception)
        {
            return new Time(DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }

}
