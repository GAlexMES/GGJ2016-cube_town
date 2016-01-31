using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject[] faces = {null, null, null, null, null, null};
    Direction moving;
    Movement attached;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void push(Vector2 pos, Vector2 offDir, int offset)
    {
        transform.position = new Vector3(pos.x+ offDir.x*offset, transform.position.y, pos.y + offDir.y * offset);
        if (attached != null)
        {
            attached.push(pos, offDir, ++offset);
        }
    }

    public void release()
    {

        if (attached != null)
        {
            attached.release();
            attached = null;
        }
    }

    public bool checkPush(Direction direction, int force)
    {
        GameObject next = faces[(int)direction];
        if (next != null)
        {
            force--;
            if(next.tag == "pushable" && force >= 0)
            {
                attached = next.GetComponent<Movement>();
                if (attached.checkPush(direction, force))
                {
                    moving = direction;
                    return true;
                }else
                {
                    attached = null;
                    return false;
                }

            }
            else
            {
                return false;
            }
        } else
        {
            return true;
        }
    }
}
