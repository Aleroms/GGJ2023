using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject[,] board;
    [SerializeField] private GameObject markerPrefab;

    //distance between markers
    [Header("Board Settings")]
    [SerializeField] private float distance;
    [SerializeField] private int row, col;
    private int currX, currZ;

    private void Awake()
    {
        InitializeBoard();
        currX = Random.Range(0, row);
        currZ = Random.Range(0, col);
    }
    private void InitializeBoard()
    {
        board = new GameObject[row,col];
        if(markerPrefab != null)
        {
            if(row > 1 && col > 1)
            {
                 for(int i=0; i<row; i++)
                {
                    for(int j=0; j<col; j++)
                    {
                        board[i, j] = Instantiate(markerPrefab, new Vector3(i * distance, 0, j * distance), Quaternion.identity);
                        board[i, j].transform.parent = this.transform;
                    }
                }
            }
            else
            {
                Debug.LogError("height or width for board is invalid");
            }
        }
        else
        {
            Debug.LogError("marker prefab is null");
        }
    }
    public bool InBounds(float i, float j)
    {
        Debug.Log(i + ">= 0 && " + i + "<= " + row + "&& " + j + ">= 0 && " + j + "<= " + col);
        return i >= 0 && i < row  && j >= 0 && j < col;
    }
    public Vector3 GetRandPosition()
    {
        return board[currX, currZ].transform.position;
    }
    public int GetCurX()
    {
        return currX;
    }
    public void SetCurX(int n)
    {
        currX += n;
    }
    public int GetCurZ()
    {
        return currZ;
    }
    public void SetCurZ(int n)
    {
        currZ += n;
    }
    public Vector3 GetPosition(int x, int z)
    {
        return board[x, z].transform.position;
    }
    
}
