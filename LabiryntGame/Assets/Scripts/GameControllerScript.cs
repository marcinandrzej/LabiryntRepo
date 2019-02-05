using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript inastance;
    public GameObject gamePanel;
    public Sprite obstackleSprite;

    private GuiScript guiScript;
    private GridScript gridScript;

    private float imageW;
    private float imageH;
    private List<GameObject> obstackles;

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
        LoadLevel();
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

    private void LoadLevel()
    {
        bool[,] lvl = new bool[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                lvl[i, j] = Random.Range(0, 10) % 2 == 0 ? true : false;
            }
        }
        gridScript.LoadLevel(10, 10, lvl);
        obstackles = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (gridScript.IsOccuppied(i, j))
                    obstackles.Add(guiScript.CreateImage("Obstackle", gamePanel.transform, new Vector2(imageW, imageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(i, j), new Vector3(0, 0, 0), obstackleSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255)));
            }
        }
    }
}
