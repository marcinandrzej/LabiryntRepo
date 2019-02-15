using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void levelButtonAction(int levelNumber);

public class MenuScript : MonoBehaviour
{
    public Sprite lockedLevel;
    public Sprite unlockedLevel;

    public Button restartButton;
    public Button helpButton;

    public GameObject mainMenuCanvas;
    public GameObject levelPanel;

    public GameObject gameCanvas;
    public GameObject gamePanel;
    public GameObject helpPanel;
    public GameObject endGamePanel;

    private GameObject[] levelButtons;
    private GameControllerScript gmaeConScript;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetMenu(GameControllerScript _gmaeConScript)
    {
        gmaeConScript = _gmaeConScript;
    }

    public void SetUpLevelPanel(GameObject[] _levelButtons, levelButtonAction _levelButtonAction)
    {
        levelButtons = _levelButtons;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int x = i;
            levelButtons[i].GetComponent<Button>().onClick.AddListener(delegate 
            { _levelButtonAction.Invoke(x);
                ActivateLevel();
            });
        }
    }

    public void UpdateLevelCleared(int levelIndex)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelIndex)
            {
                levelButtons[i].GetComponent<Button>().enabled = false;
                levelButtons[i].GetComponent<Image>().sprite = lockedLevel;
            }
            else
            {
                levelButtons[i].GetComponent<Button>().enabled = true;
                levelButtons[i].GetComponent<Image>().sprite = unlockedLevel;
            }
        }
    }

    public void ActiveDeactiveHelp()
    {
        helpPanel.SetActive(!helpPanel.active);
        gamePanel.SetActive(!helpPanel.active);
        restartButton.enabled = !helpPanel.active;
    }

    public void ActiveMainMenu()
    {
        if (helpPanel.active == true)
            ActiveDeactiveHelp();
        endGamePanel.SetActive(false);
        gameCanvas.SetActive(false);
        UpdateLevelCleared(gmaeConScript.UnlockedLevelCount);
        mainMenuCanvas.SetActive(true);
    }

    public void ActivateLevel()
    {
        mainMenuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        endGamePanel.SetActive(false);
        restartButton.enabled = true;
        helpButton.enabled = true;
    }

    public void EndOfLevels()
    {
        endGamePanel.SetActive(true);
        restartButton.enabled = false;
        helpButton.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
