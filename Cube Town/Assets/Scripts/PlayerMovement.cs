using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    bool moved = false;
    Vector3 start;
    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private float m_TimeCounter = 0F;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        start = transform.position;
    }


    void Update()
    {
        if(transform.position.y < -2)
        {
            transform.position = start;
        }

        moveDirection = new Vector3(0, 0, 0);

        if (controller.isGrounded && !moved)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection = new Vector3(1, 0, 0);
                moved = true;

            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = new Vector3(-1, 0, 0);
                moved = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = new Vector3(0, 0, 1);
                moved = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = new Vector3(0, 0, -1);
                moved = true;
            }
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            m_TimeCounter = 0F;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                moved = false;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                moved = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moved = false;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                moved = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection);
        m_TimeCounter = m_TimeCounter + Time.deltaTime;
    }
}