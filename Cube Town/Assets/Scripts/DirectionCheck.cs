using UnityEngine;
using System.Collections;

public class DirectionCheck : MonoBehaviour
{

    Direction facing;
    GameObject[] faces;

    // Use this for initialization
    void Start()
    {
        switch (name)
        {
            case "Up":
                facing = Direction.UP;
                break;
            case "Down":
                facing = Direction.DOWN;
                break;
            case "Left":
                facing = Direction.LEFT;
                break;
            case "Right":
                facing = Direction.RIGHT;
                break;
            case "Front":
                facing = Direction.FORWARD;
                break;
            default:
                facing = Direction.BACKWARD;
                break;
        }

        faces = this.GetComponentInParent<Movement>().faces;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("(" + other.gameObject.tag + ")");
        if (!other.isTrigger && other.gameObject.tag != "Untagged")
        {
            faces[(int)facing] = other.gameObject;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.tag != "Untagged")
        {
            faces[(int)facing] = null;
        }
    }
}
