using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 10.0F;
    
    public GameObject[] objs;

    bool moved = false;
    Vector3 start;
    Vector2 animStart;
    Vector2 animTarget;
    float animTime = 0f;
    float animDuration = .2f;
    bool moving = false;
    bool doNext = false;
    private Vector2 nextMove = Vector2.zero;

    AudioSource source;

    // Use this for initialization
    void Start()
    {
        //Get the Starting position of the Player
        start = transform.position;

        //Get the AudioSource to play Audio Clips
        source = GetComponent<AudioSource>();

        //Get the current active SceneName
        Game.current = SceneManager.GetActiveScene().name;

    }

    public void reset()
    {
        ResetScene.reset();
    }

    //This Function gets called every frame
    void Update()
    {
        animTime -= Time.deltaTime;

        //Reset to start, if the player has fallen down
        if (transform.position.y < -10)
        {
            reset();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            doNext = true;
            nextMove = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            doNext = true;
            nextMove = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            doNext = true;
            nextMove = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            doNext = true;
            nextMove = Vector2.down;
        }

        if (animTime > 0f)
        {
            Vector2 step = Vector2.Lerp(animStart, animTarget, (animDuration - animTime) / animDuration);
            transform.position = new Vector3(step.x, transform.position.y, step.y);
        }
        if (animTime <= 0f)
        {
            //Just stopped moving
            if (moving) {
                moving = false;
                transform.position = new Vector3(Mathf.Round(animTarget.x), transform.position.y, Mathf.Round(animTarget.y));
            }
            if (doNext)
            {
                doNext = false;
                moving = true;
                animTime = animDuration;
                animStart = new Vector2(transform.position.x, transform.position.z);
                animTarget = new Vector2(animStart.x+nextMove.x, animStart.y + nextMove.y);

                Vector3 target = new Vector3(animTarget.x, transform.position.y, animTarget.y);
                VectorUtil.round(target);
                foreach (GameObject block in GameObject.FindGameObjectsWithTag("pushable"))
                {
                    Vector3 pos = VectorUtil.copy(block.transform.position);
                    VectorUtil.round(pos);
                    if (Vector3.Equals(target, pos))
                    {
                        block.GetComponent<PushBlock>().push(nextMove, animDuration);
                    }
                }
            }
        }
    }
}