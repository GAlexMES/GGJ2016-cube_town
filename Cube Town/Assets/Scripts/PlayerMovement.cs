using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;

    bool moved = false;
    Vector3 start;
    Vector2 animStart;
    Vector2 animTarget;
    float animTime = 0f;
    float animDuration = .2f;
    bool moving = false;
    bool doNext = false;
    Direction direction;
    Vector2 dir;
    private Vector2 nextMove = Vector2.zero;

    Movement movement;

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

        movement = GetComponent<Movement>();
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
            direction = Direction.BACKWARD;
            nextMove = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            doNext = true;
            direction = Direction.FORWARD;
            nextMove = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            doNext = true;
            direction = Direction.RIGHT;
            nextMove = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            doNext = true;
            direction = Direction.LEFT;
            nextMove = Vector2.down;
        }

        if (animTime > 0f)
        {
            Vector2 step = Vector2.Lerp(animStart, animTarget, (animDuration - animTime) / animDuration);
            movement.push(step, dir, 0);
        }
        if (animTime <= 0f)
        {
            //Just stopped moving
            if (moving) {
                moving = false;
                movement.push(new Vector2(Mathf.Round(animTarget.x), Mathf.Round(animTarget.y)), dir, 0);
                movement.release();
            }
            if (doNext)
            {
                doNext = false;
                if (movement.checkPush(direction, 1))
                {
                    moving = true;
                    animTime = animDuration;
                    animStart = new Vector2(transform.position.x, transform.position.z);
                    dir = nextMove;
                    animTarget = new Vector2(animStart.x + nextMove.x, animStart.y + nextMove.y);

                    Vector3 target = new Vector3(animTarget.x, transform.position.y, animTarget.y);
                    VectorUtil.round(target);
                }

            }
        }
    }
}