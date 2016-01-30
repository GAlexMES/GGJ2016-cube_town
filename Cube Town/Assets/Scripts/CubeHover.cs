using UnityEngine;
using System.Collections;

public class CubeHover : MonoBehaviour
{
    float maxUpAndDown = 0.6F;             // amount of meters going up and down
    float speed = 100;            // up and down speed
    protected float angle = 0;            // angle to determin the height by using the sinus
    protected float toDegrees = Mathf.PI / 180;    // radians to degrees
    float y;

    // Use this for initialization
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        if (angle > 360) angle -= 360;
        transform.position = new Vector3(transform.position.x, y + maxUpAndDown * Mathf.Sin(angle * toDegrees), transform.position.z);
    }
}
