using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    private GameObject player;
    private Camera mainCamera;
    public float m_CameraOffset;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
	}
}
