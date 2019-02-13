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
                lvl[3, 0] = true;
                lvl[6, 0] = true;
                lvl[0, 1] = true;
                lvl[7, 2] = true;
                lvl[4, 3] = true;
                lvl[7, 4] = true;
                lvl[3, 5] = true;
                lvl[6, 6] = true;
                lvl[1, 7] = true;
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
                xy[0] = 3;
                xy[1] = 2;
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
                xy[1] = 6;
                break;
            default:
                break;
        }
        return xy;
    }
}
