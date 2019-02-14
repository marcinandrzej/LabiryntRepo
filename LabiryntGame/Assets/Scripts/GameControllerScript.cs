using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public const int GRID_DIMENSION = 8;

    public Text levelTxt;
    public GameObject gamePanel;
    public Sprite obstackleSprite;
    public Sprite playerSprite;
    public Sprite endPointSprite;

    private GuiScript guiScript;
    private GridScript gridScript;
    private LevelsScript levelScript;

    private byte currentLvl;
    private byte levelCount;
    private bool win;
    private float imageW;
    private float imageH;
    private List<GameObject> gameObjects;
    private GameObject player;

    public float ImageW
    {
        get
        {
            return imageW;
        }

        set
        {
            imageW = value;
        }
    }

    public float ImageH
    {
        get
        {
            return imageH;
        }

        set
        {
            imageH = value;
        }
    }

    public bool Win
    {
        get
        {
            return win;
        }

        set
        {
            win = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        guiScript = gameObject.AddComponent<GuiScript>();
        gridScript = gameObject.AddComponent<GridScript>();
        levelScript = gameObject.AddComponent<LevelsScript>();
        levelCount = LevelsScript.LEVEL_COUNT;
        SetGameGrid(GRID_DIMENSION, GRID_DIMENSION, gamePanel);
        StartLevel(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartLevel(byte level)
    {
        currentLvl = level;
        LoadLevel(currentLvl);
    }

    private void SetGameGrid(int columnCount, int rowsCount, GameObject gridPanel)
    {
        ImageW = Mathf.Abs(gridPanel.GetComponent<RectTransform>().sizeDelta.x) / (float)columnCount;
        ImageH = Mathf.Abs(gridPanel.GetComponent<RectTransform>().sizeDelta.y) / (float)rowsCount;
        gridScript.SetGridOccupancy(columnCount, rowsCount);
        gridScript.SetGridCoordinates(gamePanel.transform, columnCount, rowsCount, ImageW, ImageH);
    }

    private void LoadLevel(int lvlNumber)
    {
        levelTxt.text = "LEVEL: " + (lvlNumber + 1).ToString();
        // SET OBSTACKLES
        gridScript.LoadLevel(GRID_DIMENSION, GRID_DIMENSION, levelScript.GetLevel(GRID_DIMENSION, lvlNumber));
        gameObjects = new List<GameObject>();
        for (int i = 0; i < GRID_DIMENSION; i++)
        {
            for (int j = 0; j < GRID_DIMENSION; j++)
            {
                if (gridScript.IsOccuppied(i, j))
                    gameObjects.Add(guiScript.CreateImage("Obstackle", gamePanel.transform, new Vector2(ImageW, ImageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(i, j), new Vector3(0, 0, 0), obstackleSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255)));
            }
        }
        // SET EXIT
        int[] xy = levelScript.GetEndPoint(lvlNumber);
        gridScript.SetEndPoint(xy);
        gameObjects.Add(guiScript.CreateImage("EndPoint", gamePanel.transform, new Vector2(ImageW, ImageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(xy[0], xy[1]), new Vector3(0, 0, 0), endPointSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255)));
        // SET PLAYER
        xy = levelScript.GetStartPoint(lvlNumber);
        player = guiScript.CreateImage("Player", gamePanel.transform, new Vector2(ImageW, ImageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   gridScript.GetCoordinates(xy[0], xy[1]), new Vector3(0, 0, 0), playerSprite, Image.Type.Sliced, new Color32(255, 255, 255, 255));
        player.AddComponent<PlayerControlScript>();
        player.GetComponent<PlayerControlScript>().SetPlayer(xy, 15, this, gridScript);
        gameObjects.Add(player);
    }

    private void ClearLevel()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    public void ResetLevel()
    {
        ClearLevel();
        LoadLevel(currentLvl);
    }

    public void EndLevel()
    {
        if (Win)
        {
            Debug.Log("win");
            currentLvl += 1;
        }
        else
        {
            Debug.Log("lose");
        }
        if (currentLvl < levelCount)
        {
            ResetLevel();
        }
    }
}
