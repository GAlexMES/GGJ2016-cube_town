using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 10.0F;
    
    public GameObject[] objs;

    bool moved = false;
    Vector3 start;

    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    AudioSource source;
    GameObject cam;

    // Use this for initialization
    void Start()
    {
        //Get the CharacterController of this Player
        controller = GetComponent<CharacterController>();

        //Get the Starting position of the Player
        start = transform.position;
        source = GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera");
    }

    //This Function gets called every frame
    void Update()
    {
        //Reset to start, if the player has fallen down
        if(transform.position.y < -10)
        {
            transform.position = start;
        }

        moveDirection = Vector3.zero;

        if (!moved)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection = new Vector3(1, 0, 0);
                moved = true;
                if(objs.Length > 0)
                {
                    foreach(GameObject obj in objs)
                    {
                        if (obj.transform.position.Equals(new Vector3(transform.position.x + 1.0F, transform.position.y, transform.position.z))){
                            obj.transform.position = new Vector3(obj.transform.position.x + 1.0F, obj.transform.position.y, obj.transform.position.z);
                        }
                    }
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = new Vector3(-1, 0, 0);
                moved = true;
                if (objs.Length > 0)
                {
                    foreach (GameObject obj in objs)
                    {
                        if (obj.transform.position.Equals(new Vector3(transform.position.x - 1.0F, transform.position.y, transform.position.z)))
                        {
                            obj.transform.position = new Vector3(obj.transform.position.x - 1.0F, obj.transform.position.y, obj.transform.position.z);
                        }
                    }
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = new Vector3(0, 0, 1);
                moved = true;
                if (objs.Length > 0)
                {
                    foreach (GameObject obj in objs)
                    {
                        if (obj.transform.position.Equals(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.0F)))
                        {
                            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 1.0F);
                        }
                    }
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = new Vector3(0, 0, -1);
                moved = true;
                if (objs.Length > 0)
                {
                    foreach (GameObject obj in objs)
                    {
                        if (obj.transform.position.Equals(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0F)))
                        {
                            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 1.0F);
                        }
                    }
                }
            }
            source.Play();
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                moved = false;
            }
        }

        //moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        transform.position = transform.position + moveDirection;
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
    }
}