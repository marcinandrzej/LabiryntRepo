using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScript : MonoBehaviour
{
    public bool[,] GetLevel(int gridDimension, int lvlNumber)
    {
        bool[,] lvl = new bool[gridDimension, gridDimension];
        for (int i = 0; i < gridDimension; i++)
        {
            for (int j = 0; j < gridDimension; j++)
            {
                lvl[i, j] = false;
            }
        }
        switch (lvlNumber)
        {
            case 0:
                lvl[0, 0] = true;
                lvl[1, 5] = true;
                lvl[6, 4] = true;
                break;
            default:
                break;
        }
        return lvl;
    }

    public int[] GetStartPoint(int lvlNumber)
    {
        int[] xy = new int[2];

        switch (lvlNumber)
        {
            case 0:
                xy[0] = 6;
                xy[1] = 0;
                break;
            default:
                break;
        }
        return xy;
    }

    public int[] GetEndPoint(int lvlNumber)
    {
        int[] xy = new int[2];

        switch (lvlNumber)
        {
            case 0:
                xy[0] = 5;
                xy[1] = 7;
                break;
            default:
                break;
        }
        return xy;
    }
}
