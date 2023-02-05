using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Board board;
    public static GameManager Instance;
    private GamplayUIManager UIManager;

    [Header("Goal Settings")]
    [SerializeField] private int digs;
    [SerializeField] private int reloadDigs;
    [SerializeField] private int totalWeeds;
    [SerializeField] private int reloadTotalWeeds;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		//DontDestroyOnLoad(gameObject);

	}
    private void Start()
    {
		board = GameObject.FindGameObjectWithTag("board").GetComponent<Board>();
        UIManager = GameObject.Find("GameplayUIManager").GetComponent<GamplayUIManager>();
        UIManager.updateNumHiddenWeeds(totalWeeds);
        UIManager.updateNumDigs(digs);
        reloadDigs = digs;
        reloadTotalWeeds = totalWeeds;
    }
    private void Update()
    {
		//win condition
        if(totalWeeds == 0)
        {
            if(UIManager != null)
			    WinCondition();
        }
        else if(digs == 0 && totalWeeds != 0)
        {
            if(UIManager != null)
                LoseCondition();
        }
    }
    public void Dig(int x, int z)
    {
		board.CheckBoardPosition(x, z);


        //update UI here
        digs--;
        UIManager.updateNumDigs(digs);
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
        UIManager.showLosePanel();
    }
    public void WinCondition()
    {
        UIManager.showWinPanel();
    }
    public void Reload()
    {
        digs = reloadDigs;
        totalWeeds = reloadTotalWeeds;

        UIManager.updateNumHiddenWeeds(totalWeeds);
        UIManager.updateNumDigs(digs);

        //have to get new reference to new reloaded board
    }
    public void ReloadBoardReference(Board reference)
    {
        board = reference;
    }
    public void UnhideWeed()
    {
        totalWeeds--;
        UIManager.updateNumHiddenWeeds(totalWeeds);
    }
}
