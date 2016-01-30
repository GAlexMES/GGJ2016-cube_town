using UnityEngine;
using System.Collections;

public class PlayerResetTrigger : MonoBehaviour {
    Vector3 start;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        start = player.transform.position;
    }

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        player.transform.position = start;
    }
}
