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

    // Use this for initialization
    void Start()
    {
        //Get the CharacterController of this Player
        controller = GetComponent<CharacterController>();

        //Get the Starting position of the Player
        start = transform.position;
    }

    //This Function gets called every frame
    void Update()
    {
        //Reset to start, if the player has fallen down
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
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                moved = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection);
    }
}