using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private Board board;
    private int currX, currZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        board = GameObject.FindGameObjectWithTag("board").GetComponent<Board>();

        transform.position = board.GetRandPosition();
        currX = board.GetCurX();
        currZ = board.GetCurZ();

        Movement();
    }
    private void Update()
    {
        Movement();
        Digging();
    }
    private void Movement()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.Instance.UIMessage("");
            currX = board.GetCurX();

            if (board.InBounds(currX - 1, currZ))
            {
                transform.position = board.GetPosition(currX - 1, currZ);
                board.SetCurX(-1);
                currX = board.GetCurX();
          
            }
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.Instance.UIMessage("");
            currX = board.GetCurX();

            if (board.InBounds(currX + 1, currZ))
            {
                transform.position = board.GetPosition(currX + 1, currZ);
                board.SetCurX(1);
                currX = board.GetCurX();
             
            }
        } else if(Input.GetKeyDown(KeyCode.W))
        {
            GameManager.Instance.UIMessage("");
            currZ = board.GetCurZ();

            if (board.InBounds(currX, currZ + 1))
            {
              
                transform.position = board.GetPosition(currX, currZ + 1);
                board.SetCurZ(1);
                currZ = board.GetCurZ();
               
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.UIMessage("");
            currZ = board.GetCurZ();

            if (board.InBounds(currX, currZ - 1))
            {
                transform.position = board.GetPosition(currX, currZ - 1);
                board.SetCurZ(-1);
                currZ = board.GetCurZ();
              
            }
        }

    }
    private void Digging()
    {
        //checks to see if the player can dig
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(SoundManager.SoundInstance != null)
                SoundManager.SoundInstance.PlaySFX("just_dig");


            if (GameManager.Instance.canPlayerDig())
            {
                GameManager.Instance.Dig(currX,currZ);
            }
            
        }
        
    }



}
