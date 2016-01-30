using UnityEngine;
using System.Collections;

public class DeathTriger : MonoBehaviour {

	

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("bam");
        ResetScene.reset();
    }
}
