using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    private const int GRID_DIMENSION = 10;

    public static GameControllerScript inastance;
    public GameObject gamePanel;
    public Sprite obstackleSprite;
    public Sprite playerSprite;
    public Sprite endPointSprite;

    private GuiScript guiScript;
    private GridScript gridScript;
    private LevelsScript levelScript;

    private float imageW;
    private float imageH;
    private List<GameObject> obstackles;
    private GameObject player;

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
        levelScript = gameObject.AddComponent<LevelsScript>();
        SetGameGrid(GRID_DIMENSION, GRID_DIMENSION, gamePanel);
        LoadLevel(0);
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

    private void LoadLevel(int lvlNumber)
    {
        // SET OBSTACKLES
        gridScript.LoadLevel(GRID_DIMENSION, GRID_DIMENSION, levelScript.GetLevel(GRID_DIMENSION, lvlNumber));
        obstackles = new List<GameObject>();
        for (int i = 0; i < GRID_DIMENSION; i++)
        {
            for (int j = 0; j < GRID_DIMENSION; j++)
            {
                if (gridScript.IsOccuppied(i, j))
                    obstackles.Add(guiScript.CreateImage("Obstackle", gamePanel.transform, new Vector2(imageW, imageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(i, j), new Vector3(0, 0, 0), obstackleSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255)));
            }
        }
        // SET EXIT
        int[] xy = levelScript.GetEndPoint(lvlNumber);
        gridScript.SetEndPoint(xy);
        obstackles.Add(guiScript.CreateImage("EndPoint", gamePanel.transform, new Vector2(imageW, imageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(xy[0], xy[1]), new Vector3(0, 0, 0), endPointSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255)));
        // SET PLAYER
        xy = levelScript.GetStartPoint(lvlNumber);
        player = guiScript.CreateImage("Player", gamePanel.transform, new Vector2(imageW, imageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(xy[0], xy[1]), new Vector3(0, 0, 0), playerSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255));
        player.AddComponent<PlayerControlScript>();
        player.GetComponent<PlayerControlScript>().SetPlayer(xy, 15, this, gridScript);
    }
}
