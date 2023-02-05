using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private Board board;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        board = GameObject.FindGameObjectWithTag("board").GetComponent<Board>();

        transform.position = board.GetRandPosition();
        //Debug.Log(transform.position);
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirZ = Input.GetAxisRaw("Vertical");
        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("x:" + posX);
            Debug.Log("Z:" + posZ);
            if (board.InBounds(posX + dirX, posZ))
            {
                Debug.Log("in bounds");
                float step = board.GetDistance() * dirX;
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
        
    }

}
