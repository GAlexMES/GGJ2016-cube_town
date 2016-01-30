using UnityEngine;
using System.Collections;

public class PushBlock : MonoBehaviour {
    public bool m_isInPosition;

    bool moving;
    Vector2 animStart;
    Vector2 animTarget;
    float animTime = 0f;
    float animDuration = .2f;

    // Use this for initialization
    void Start () {
        m_isInPosition = false;
	}
	
	// Update is called once per frame
	void Update () {
        animTime -= Time.deltaTime;

        if (animTime > 0f)
        {
            Vector2 step = Vector2.Lerp(animStart, animTarget, (animDuration - animTime) / animDuration);
            transform.position = new Vector3(step.x, transform.position.y, step.y);
        } else if (moving)
        {
            moving = false;
            transform.position = new Vector3(Mathf.Round(animTarget.x), transform.position.y, Mathf.Round(animTarget.y));
        }
    }

    public void push(Vector2 direction, float duration )
    {

        Debug.Log("!");
        moving = true;
        animDuration = duration;
        animTime = animDuration;
        animStart = new Vector2(transform.position.x, transform.position.z);
        animTarget = new Vector2(animStart.x + direction.x, animStart.y + direction.y);
    }
}
