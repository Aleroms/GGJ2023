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
    private int weeds;

    [Header("Art Assets")]
    [SerializeField] private GameObject weed;
    [SerializeField] private GameObject sprout;
    [SerializeField] private GameObject hiddenSprout;
    [SerializeField] private GameObject deadPlant;

    private void Awake()
    {
        //weeds = 2;
        
        InitializeBoard();
        
        currX = Random.Range(0, row);
        currZ = Random.Range(0, col);

       
    }
    private void Start()
    {
        GameManager.Instance.ReloadBoardReference(this);
        weeds = GameManager.Instance.getTotalWeeds();
        InitWeeds();
    }
    private void InitializeBoard()
    {

        board = new GameObject[row,col];
        if(markerPrefab != null)
        {
            if(row > 1 && col > 1)
            {
                //initializes the board
                for(int i=0; i<row; i++)
                {
                    for(int j=0; j<col; j++)
                    {
                        board[i, j] = Instantiate(markerPrefab);
                        board[i, j].transform.parent = this.transform;
                        board[i, j].transform.localPosition = new Vector3(i * distance, 0, j * distance);
                        board[i, j].transform.rotation = Quaternion.identity;

                        
                        //Setting the plant model
                        Tile current = board[i, j].GetComponent<Tile>();
                        current.current_state = Tile.Slot.HiddenSeed;
                        current.InitModel();
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
    private void InitWeeds()
    {
        //randomly sets the weeds in the board
        int prevx = Random.Range(0, row);
        int prevy = Random.Range(0, col);
        int x, y;
        for (int a = 0; a < weeds; a++)
        {
            x = Random.Range(0, row);
            y = Random.Range(0, col);
            if (prevx != x && prevy != y)
                board[x, y].GetComponent<Tile>().current_state = Tile.Slot.HiddenWeed;
            else
            {
                x = Random.Range(0, row);
                y = Random.Range(0, col);
                board[x, y].GetComponent<Tile>().current_state = Tile.Slot.HiddenWeed;
            }
            prevx = x;
            prevy = y;
        }
    }
    private int CheckAdjacentWeed()
    {
        int totalWeed = 0;
        int leftPos = currX - 1;
        int rightPos = currX + 1;
        int upPos = currZ + 1;
        int downPos = currZ - 1;

        //check left
        if (InBounds(leftPos, currZ))
        {
            Tile left = board[leftPos, currZ].GetComponent<Tile>();
            if (left.current_state == Tile.Slot.HiddenWeed)
                totalWeed++;
        }
        //check right
        if (InBounds(rightPos, currZ))
        {
            Tile right = board[rightPos, currZ].GetComponent<Tile>();
            if (right.current_state == Tile.Slot.HiddenWeed)
                totalWeed++;
        }
        //check up
        if (InBounds(currX, upPos))
        {
            Tile up = board[currX, upPos].GetComponent<Tile>();
            if (up.current_state == Tile.Slot.HiddenWeed)
                totalWeed++;
        }
        //check down
        if (InBounds(currX, downPos))
        {
            Tile down = board[currX, downPos].GetComponent<Tile>();
            if (down.current_state == Tile.Slot.HiddenWeed)
                totalWeed++;
        }

        Debug.Log("THERE ARE (IS) " + totalWeed + " NEARBY");
        return totalWeed;
    }
    public bool InBounds(float i, float j)
    {
        //Debug.Log(i + ">= 0 && " + i + "<= " + row + "&& " + j + ">= 0 && " + j + "<= " + col);
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
    public void CheckBoardPosition(int x, int z)
    {
        Tile curr = board[x, z].GetComponent<Tile>();

        if(curr.current_state == Tile.Slot.HiddenWeed)
        {
            
            curr.UpdateModel(Tile.Slot.Weed);

            if (SoundManager.SoundInstance != null)
                SoundManager.SoundInstance.PlaySFX("digpop");

            GameManager.Instance.UnhideWeed();
        } 
        else if(curr.current_state == Tile.Slot.HiddenSeed)
        {
            curr.UpdateModel(Tile.Slot.Plant);

            if (SoundManager.SoundInstance != null)
                SoundManager.SoundInstance.PlaySFX("digpop");


            int adjacentWeeds = CheckAdjacentWeed();
            GameManager.Instance.UIMessage("There are (is) " + adjacentWeeds + " nearby!");
            
        }
    }
    
}
