using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Board board;
    public static GameManager Instance;

    [Header("Goal Settings")]
    [SerializeField] private int digs;
    [SerializeField] private int totalWeeds;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

	}
    private void Start()
    {
		board = GameObject.FindGameObjectWithTag("board").GetComponent<Board>();
    }
    private void Update()
    {
		//win condition
        if(totalWeeds == 0)
        {
			WinCondition();
        }
        else if(digs == 0 && totalWeeds != 0)
        {
            LoseCondition();
        }
    }
    public void Dig(int x, int z)
    {
		board.CheckBoardPosition(x, z);
		
		//update UI here

		digs--;
    }
	public bool canPlayerDig()
    {
		return digs > 0;
    }
	public int getTotalWeeds()
    {
		return totalWeeds;
    }
	public void LoseCondition()
    {

    }
    public void WinCondition()
    {

    }
}
