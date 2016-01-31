using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

    GameObject cam;
    GameObject player;
    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, player.transform.position.z);
    }
}
