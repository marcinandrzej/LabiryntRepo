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

    private void Move(int deltaX, int deltaY)
    {
        inMove = true;
        int[] blocadePos = gridScript.SeekBlocade(posX, posY, deltaX, deltaY);
        if (blocadePos != null)
        {
            int deltaPos = Mathf.Abs(blocadePos[0] - posX) + Mathf.Abs(blocadePos[1] - posY);
            if (gridScript.IsEndPoint(blocadePos))
            {
                StartCoroutine(MoveCoroutine(blocadePos, true));
            }
            else if(deltaPos > 1)
            {
                blocadePos[0] -= deltaX;
                blocadePos[1] -= deltaY;
                StartCoroutine(MoveCoroutine(blocadePos, false));
            }
            else
            {
                inMove = false;
            }
        }
        else
        {
            inMove = false;
        }
    }

    private IEnumerator MoveCoroutine(int[] newPos, bool isEnd)
    {
        posX = newPos[0];
        posY = newPos[1];

        Vector2 destination = gridScript.GetCoordinates(posX, posY);

        while (rectTransform.anchoredPosition != destination)
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, destination, speed);
            yield return new WaitForEndOfFrame();
        }
        rectTransform.anchoredPosition = destination;
        inMove = false;
    }
}
