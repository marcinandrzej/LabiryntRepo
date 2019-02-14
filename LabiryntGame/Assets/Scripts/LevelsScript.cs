using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScript : MonoBehaviour
{
    public const byte LEVEL_COUNT = 11;

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
            case 1:
                lvl[1, 0] = true;
                lvl[2, 0] = true;
                lvl[4, 0] = true;
                lvl[7, 1] = true;
                lvl[3, 2] = true;
                lvl[1, 3] = true;
                lvl[0, 4] = true;
                lvl[4, 5] = true;
                lvl[1, 6] = true;
                lvl[6, 6] = true;
                break;
            case 2:
                lvl[1, 0] = true;
                lvl[7, 0] = true;
                lvl[3, 1] = true;
                lvl[0, 2] = true;
                lvl[6, 3] = true;
                lvl[4, 4] = true;
                lvl[2, 5] = true;
                lvl[5, 6] = true;
                lvl[0, 7] = true;
                lvl[7, 7] = true;
                break;
            case 3:
                lvl[2, 0] = true;
                lvl[5, 1] = true;
                lvl[1, 2] = true;
                lvl[6, 3] = true;
                lvl[2, 4] = true;
                lvl[4, 4] = true;
                lvl[7, 5] = true;
                lvl[1, 6] = true;
                lvl[6, 6] = true;
                lvl[7, 6] = true;
                break;
            case 4:
                lvl[1, 0] = true;
                lvl[4, 1] = true;
                lvl[7, 1] = true;
                lvl[5, 2] = true;
                lvl[0, 3] = true;
                lvl[5, 3] = true;
                lvl[1, 4] = true;
                lvl[4, 5] = true;
                lvl[6, 6] = true;
                lvl[2, 7] = true;
                break;
            case 5:
                lvl[5, 0] = true;
                lvl[2, 1] = true;
                lvl[0, 2] = true;
                lvl[7, 2] = true;
                lvl[2, 3] = true;
                lvl[3, 3] = true;
                lvl[6, 4] = true;
                lvl[6, 5] = true;
                lvl[1, 6] = true;
                lvl[4, 7] = true;
                break;
            case 6:
                lvl[1, 0] = true;
                lvl[4, 1] = true;
                lvl[5, 2] = true;
                lvl[2, 3] = true;
                lvl[7, 3] = true;
                lvl[1, 4] = true;
                lvl[6, 4] = true;
                lvl[1, 5] = true;
                lvl[4, 6] = true;
                lvl[2, 7] = true;
                break;
            case 7:
                lvl[2, 1] = true;
                lvl[7, 1] = true;
                lvl[1, 2] = true;
                lvl[2, 2] = true;
                lvl[5, 2] = true;
                lvl[6, 3] = true;
                lvl[6, 4] = true;
                lvl[5, 5] = true;
                lvl[0, 6] = true;
                lvl[3, 7] = true;
                break;
            case 8:
                lvl[3, 0] = true;
                lvl[1, 1] = true;
                lvl[6, 1] = true;
                lvl[4, 2] = true;
                lvl[4, 3] = true;
                lvl[1, 4] = true;
                lvl[7, 4] = true;
                lvl[0, 5] = true;
                lvl[5, 6] = true;
                lvl[1, 7] = true;
                break;
            case 9:
                lvl[4, 0] = true;
                lvl[0, 1] = true;
                lvl[6, 1] = true;
                lvl[2, 3] = true;
                lvl[5, 4] = true;
                lvl[1, 5] = true;
                lvl[7, 5] = true;
                lvl[0, 6] = true;
                lvl[6, 6] = true;
                lvl[3, 7] = true;
                break;
            case 10:
                lvl[5, 0] = true;
                lvl[2, 1] = true;
                lvl[6, 2] = true;
                lvl[1, 3] = true;
                lvl[5, 3] = true;
                lvl[6, 4] = true;
                lvl[0, 5] = true;
                lvl[3, 6] = true;
                lvl[1, 7] = true;
                lvl[5, 7] = true;
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
            case 1:
                xy[0] = 3;
                xy[1] = 4;
                break;
            case 2:
                xy[0] = 6;
                xy[1] = 1;
                break;
            case 3:
                xy[0] = 4;
                xy[1] = 6;
                break;
            case 4:
                xy[0] = 1;
                xy[1] = 2;
                break;
            case 5:
                xy[0] = 3;
                xy[1] = 2;
                break;
            case 6:
                xy[0] = 1;
                xy[1] = 2;
                break;
            case 7:
                xy[0] = 5;
                xy[1] = 1;
                break;
            case 8:
                xy[0] = 1;
                xy[1] = 3;
                break;
            case 9:
                xy[0] = 2;
                xy[1] = 1;
                break;
            case 10:
                xy[0] = 1;
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
            case 1:
                xy[0] = 5;
                xy[1] = 2;
                break;
            case 2:
                xy[0] = 1;
                xy[1] = 6;
                break;
            case 3:
                xy[0] = 4;
                xy[1] = 1;
                break;
            case 4:
                xy[0] = 4;
                xy[1] = 6;
                break;
            case 5:
                xy[0] = 3;
                xy[1] = 4;
                break;
            case 6:
                xy[0] = 6;
                xy[1] = 2;
                break;
            case 7:
                xy[0] = 2;
                xy[1] = 4;
                break;
            case 8:
                xy[0] = 6;
                xy[1] = 3;
                break;
            case 9:
                xy[0] = 5;
                xy[1] = 5;
                break;
            case 10:
                xy[0] = 6;
                xy[1] = 6;
                break;
            default:
                break;
        }
        return xy;
    }
}
