using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript inastance;
    public GameObject gamePanel;

    private GuiScript guiScript;
    private GridScript gridScript;

    private float imageW;
    private float imageH;

    void Awake()
    {
        if (inastance == null)
            inastance = this;
    }

    // Use this for initialization
    void Start ()
    {
        guiScript = gameObject.AddComponent<GuiScript>();
        gridScript = gamePanel.AddComponent<GridScript>();
        SetGameGrid(10, 10, gamePanel);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void SetGameGrid(int columnCount, int rowsCount, GameObject gridPanel)
    {
        imageW = Mathf.Abs(gridPanel.GetComponent<RectTransform>().sizeDelta.x) / (float)columnCount;
        imageH = Mathf.Abs(gridPanel.GetComponent<RectTransform>().sizeDelta.y) / (float)rowsCount;
        gridScript.SetGridOccupancy(columnCount, rowsCount);
        gridScript.SetGridCoordinates(gamePanel.transform, columnCount, rowsCount, imageW, imageH);
    }
}
