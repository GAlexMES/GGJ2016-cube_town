using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelLoader : MonoBehaviour {
    public string m_NextLevel;
    

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            while (audio.isPlaying)
            {

            }
            SceneManager.LoadScene(m_NextLevel);
        }
    }
}
