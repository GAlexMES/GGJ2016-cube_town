using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

    GameObject cam;
    public float camDistance = 100;
    public float camAngle = 45;
    public Vector3 up = new Vector3(0, 1, 0);


    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        float angle = camAngle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        Vector3 camPos = camDistance * direction;
        camPos = transform.TransformPoint(camPos);
        cam.transform.position = camPos;
        Quaternion camRot = Quaternion.LookRotation(-transform.TransformDirection(direction), up);
        //Quaternion camRot = Quaternion.LookRotation(-camPos, up);
        cam.transform.rotation = camRot;
    }
}
