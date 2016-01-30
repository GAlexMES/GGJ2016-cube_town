using UnityEngine;
using System.Collections;

public class DeathTriger : MonoBehaviour {

	

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ResetScene.reset();
        }
    }
}
