using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    private float speed;
    private RectTransform rectTransform;
    private GameControllerScript gameController;
    private GridScript gridScript;
    private int posX;
    private int posY;
    private bool inMove;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!inMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Move(1, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Move(-1, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Move(0, -1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(0, 1);
            }
        }
    }

    public void SetPlayer(int[] xy, float _speed, GameControllerScript _gameController, GridScript _gridScript)
    {
        posX = xy[0];
        posY = xy[1];
        speed = _speed;
        inMove = false;
        rectTransform = gameObject.GetComponent<RectTransform>();
        gameController = _gameController;
        gridScript = _gridScript;
    }

    public void Move(int deltaX, int deltaY)
    {
        inMove = true;
        int[] blocadePos = gridScript.SeekBlocade(posX, posY, deltaX, deltaY);
        Vector2 destination;
        if (blocadePos != null)
        {
            int deltaPos = Mathf.Abs(blocadePos[0] - posX) + Mathf.Abs(blocadePos[1] - posY);
            if (gridScript.IsEndPoint(blocadePos))
            {
                gameController.Win = true;
                destination = gridScript.GetCoordinates(blocadePos[0], blocadePos[1]);
                StartCoroutine(MoveCoroutine(destination, true));
            }
            else if(deltaPos > 1)
            {
                blocadePos[0] -= deltaX;
                blocadePos[1] -= deltaY;
                posX = blocadePos[0];
                posY = blocadePos[1];
                destination = gridScript.GetCoordinates(blocadePos[0], blocadePos[1]);
                StartCoroutine(MoveCoroutine(destination, false));
            }
            else
            {
                inMove = false;
            }
        }
        else
        {
            gameController.Win = false;
            destination = OutOfGridPosition(deltaX, deltaY);
            StartCoroutine(MoveCoroutine(destination, true));
        }
    }

    private IEnumerator MoveCoroutine(Vector2 destination, bool isEnd)
    {
        while (rectTransform.anchoredPosition != destination)
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, destination, speed);
            yield return new WaitForEndOfFrame();
        }
        rectTransform.anchoredPosition = destination;
        if (!isEnd)
        {
            inMove = false;
        }
        else
        {
            gameController.EndLevel();
        }
    }

    private Vector2 OutOfGridPosition(int deltaX, int deltaY)
    {
        float _x = 0.0f;
        float _y = 0.0f;
        if (deltaX == 1)
        {
            _x = gameController.ImageW * (1 + GameControllerScript.GRID_DIMENSION);
            _y = rectTransform.anchoredPosition.y;
        }
        else if (deltaX == -1)
        {
            _x =  -gameController.ImageW;
            _y = rectTransform.anchoredPosition.y;
        }
        else if (deltaY == 1)
        {
            _y = -gameController.ImageH * (1 + GameControllerScript.GRID_DIMENSION);
            _x = rectTransform.anchoredPosition.x;
        }
        else
        {
            _y = gameController.ImageH;
            _x = rectTransform.anchoredPosition.x;
        }
        Vector2 pos = new Vector2(_x, _y);
        return pos;
    }
}
