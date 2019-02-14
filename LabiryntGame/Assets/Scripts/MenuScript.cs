using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //public GameObject mainMenuCanvas;
    public GameObject gameCanvas;
    public GameObject gamePanel;
    public GameObject helpPanel;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateView(string text, GameObject textObj)
    {
        textObj.GetComponent<Text>().text = text;
    }

    public void ActiveDeactiveHelp()
    {
        helpPanel.SetActive(!helpPanel.active);
        gamePanel.SetActive(!helpPanel.active);
    }

    public void ActiveMainMenu()
    {
        //mainMenuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }
}
