using System;
using UnityEngine;
using UnityEngine.UI;

public class DataBaseChange : MonoBehaviour {

    public Text cityName;
    public Text buttonText;
    public Text inputText;
    public InputField inputField;

    //state pattern
    ChangeBtnState state = new NotDisplayedField();

    internal string stopsFile;


    public void OnClick()
    {
        ErrorHandler.hide();
        state.OnClick(this);
    }


    private void changeDatabase()
    {
        Init init = GameObject.FindGameObjectWithTag("Init").GetComponent<Init>();
        init.city = cityName.text;
        init.myStart();
    }


    interface ChangeBtnState
    {
        void OnClick(DataBaseChange dbc);
    }


    class NotDisplayedField : ChangeBtnState
    {
        public void OnClick(DataBaseChange dbc)
        {
            dbc.inputField.gameObject.SetActive(true);
            dbc.buttonText.text = "OK";
            dbc.state = new DisplayedField();
        }
    }


    class DisplayedField : ChangeBtnState
    {
        public void OnClick(DataBaseChange dbc)
        {
            //if (dbc.inputText.text.CompareTo)
            try
            {
                string path = Application.dataPath + "/Data/" + dbc.inputText.text + "/" + dbc.stopsFile + ".txt";
                System.IO.File.OpenRead(Application.dataPath + "/Data/" + dbc.inputText.text + "/" + dbc.stopsFile + ".txt");
                dbc.inputField.gameObject.SetActive(false);
                dbc.buttonText.text = "Zmeň";
                dbc.cityName.text = dbc.inputText.text;
                dbc.changeDatabase();
                dbc.state = new NotDisplayedField();
            }
            catch (Exception)
            {
                ErrorHandler.printErrorMsg("Súbory s dátami neboli nájdené!\n Skontrolujte preklepy.");
            }
        }
    }

}
