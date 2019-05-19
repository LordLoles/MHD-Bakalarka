using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SearchButtonOnClick : MonoBehaviour
{

    public Text start;
    public Text fin;
    public Text time;
    public Text amount;


    public void OnClick()
    {
        ErrorHandler.hide();
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        Init initScript = init.GetComponent<Init>();
        initScript.startSearching(start.text, fin.text, getTime(), getAmount());
    }


    private Time getTime()
    {
        try
        {
            string[] input = time.text.Split(':');
            return new Time(Int32.Parse(input[0]), Int32.Parse(input[1]));
        }
        catch(Exception e)
        {
            if (time.text != "") ErrorHandler.printErrorMsgNoThrow("Zlý formát času!\n Vyhľadáva sa od momentálneho času");
            return new Time(DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }


    private int getAmount()
    {
        try
        {
            return Int32.Parse(amount.text);
        }
        catch (Exception)
        {
            if (amount.text != "") ErrorHandler.printErrorMsgNoThrow("Zlý počet zastávok určených na výpis!\n Vyhľadávajú sa 3 výsledky");
            return 3;
        }
    }

}
