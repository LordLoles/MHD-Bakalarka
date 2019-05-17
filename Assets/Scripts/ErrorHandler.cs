using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorHandler : MonoBehaviour
{

    public static Text chybaTxt;

    public static void hide()
    {
        chybaTxt.enabled = false;
    }

    public static void printErrorMsg(string msg)
    {
        chybaTxt.text = msg;
        chybaTxt.enabled = true;
        throw new System.Exception(msg);
    }

}
