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
        //Debug.Log(transform.position);

        Debug.Log("current X:" + currX + " current z:" + currZ);
        Movement();
    }
    private void Update()
    {
         Movement();
        //float dirX = Input.GetAxisRaw("Horizontal");
       // Debug.Log(dirX);
    }
    private void Movement()
    {
        
       // float dirX = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.A))
        {
            currX = board.GetCurX();

            if (board.InBounds(currX - 1, currZ))
            {
                transform.position = board.GetPosition(currX - 1, currZ);
                board.SetCurX(-1);
                currX = board.GetCurX();
                Debug.Log("current X:" + currX + " current z:" + currZ);
            }
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            currX = board.GetCurX();

            if (board.InBounds(currX + 1, currZ))
            {
                transform.position = board.GetPosition(currX + 1, currZ);
                board.SetCurX(1);
                currX = board.GetCurX();
                Debug.Log("current X:" + currX + " current z:" + currZ);
            }
        } else if(Input.GetKeyDown(KeyCode.W))
        {
            currZ = board.GetCurZ();

            if (board.InBounds(currX, currZ + 1))
            {
                Debug.Log("current X:" + currX + " current z:" + (currZ+1));
                transform.position = board.GetPosition(currX, currZ + 1);
                board.SetCurZ(1);
                currZ = board.GetCurZ();
                Debug.Log("current X:" + currX + " current z:" + currZ);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currZ = board.GetCurZ();

            if (board.InBounds(currX, currZ - 1))
            {
                transform.position = board.GetPosition(currX, currZ - 1);
                board.SetCurZ(-1);
                currZ = board.GetCurZ();
                Debug.Log("current X:" + currX + " current z:" + currZ);
            }
        }




    }


    /*
     if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            float step = board.GetDistance();
            Debug.Log(step * dirX);
            if (board.InBounds(posX + step, posZ))
            {
                Debug.Log("in bounds");
                
                transform.position = new Vector3(posX + step, 0, posZ);
            }
            else
            {
                Debug.Log("error");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("x:" + posX);
            Debug.Log("Z:" + posZ);
            float step = board.GetDistance() * dirZ;
            transform.position = new Vector3(posX, 0, posZ + step);
        }
     
     */

}
