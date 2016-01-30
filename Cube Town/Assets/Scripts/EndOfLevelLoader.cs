using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelLoader : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            if(index == -1)
            {
                index = 1;
            }
            SceneManager.LoadScene((SceneManager.GetSceneAt(index+1)).name);
        }
    }
}
