using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtn : MonoBehaviour {

    private PathShowing pathShowing;

    public GameObject button;

    private void Start()
    {
        GameObject init = GameObject.FindGameObjectWithTag("Init");
        pathShowing = init.GetComponent<PathShowing>();
    }


    public void OnClick()
    {
        ErrorHandler.hide();
        pathShowing.redoLastState();
    }


    private void Update()
    {
        if (pathShowing.pathsMemory.numberOfStates() < 1) button.SetActive(false);
        else button.SetActive(true);
    }

}
