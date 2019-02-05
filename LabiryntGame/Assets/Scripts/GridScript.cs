using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    private bool[,] gridCellsOcuppancy;
    private Vector2[,] gridCellsCoordinates;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector2 GetCoordinates(int x, int y)
    {
        return gridCellsCoordinates[x, y];
    }

    public bool IsOccuppied(int x, int y)
    {
        return gridCellsOcuppancy[x, y];
    }

    public void SetGridCoordinates(Transform panel, int columnCount, int rowsCount, float imageW, float imageH)
    {
        gridCellsCoordinates = new Vector2[columnCount, rowsCount];
        float offsetX = imageW / 2.0f;
        float offsetY = -imageH / 2.0f;
        for (int j = 0; j < rowsCount; j++)
        {
            for (int i = 0; i < columnCount; i++)
            {
                gridCellsCoordinates[i, j] = new Vector2(offsetX + (i * imageW), offsetY + (j * -imageH));
            }
        }
    }

    public void SetGridOccupancy(int columnCount, int rowsCount)
    {
        gridCellsOcuppancy = new bool[columnCount, rowsCount];
        for (int j = 0; j < rowsCount; j++)
        {
            for (int i = 0; i < columnCount; i++)
            {
                gridCellsOcuppancy[i, j] = false;
            }
        }
    }

    public void LoadLevel(int columnCount, int rowsCount, bool[,] level)
    {
        for (int j = 0; j < rowsCount; j++)
        {
            for (int i = 0; i < columnCount; i++)
            {
                gridCellsOcuppancy[i, j] = level[i,j];
            }
        }
    }

    private bool IsInGrid(int x, int y)
    {
        if (x >= 0 && x < gridCellsCoordinates.GetLength(0) && y >= 0 && y < gridCellsCoordinates.GetLength(1))
            return true;
        return false;
    }

    public int[] SeekBlocade(int x, int y, int deltaX, int deltaY)
    {
        int[] xy = new int[2];
        int _x = x + deltaX;
        int _y = y + deltaY;
        while (IsInGrid(_x,_y))
        {
            if (gridCellsOcuppancy[_x,_y] == true)
            {
                xy[0] = _x;
                xy[1] = _y;
                return xy;
            }
            else
            {
                _x += deltaX;
                _y += deltaY;
            }
        }
        return null;
    }
}
