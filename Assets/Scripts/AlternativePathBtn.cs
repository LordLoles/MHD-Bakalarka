using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativePathBtn : MonoBehaviour {

    private StopObjectHolder soh;

    public void OnClick()
    {
        soh = GetComponent<StopObjectHolder>();
        soh.panelManager.pathShowing.showAlternativePath(soh.zastavka);
    }

}
