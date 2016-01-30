using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

    GameObject cam;

    // Use this for initialization
    void Start () {

        cam = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {

        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
    }
}
