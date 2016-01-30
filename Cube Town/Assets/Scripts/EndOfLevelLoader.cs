using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelLoader : MonoBehaviour {
    public string m_NextLevel;
    private bool m_AllInPosition;

	void OnTriggerEnter(Collider other)
    {
        GameObject[] objs = other.GetComponent<PlayerMovement>().objs;

        foreach (GameObject obj in objs)
        {
            if (obj.GetComponent<RightBlock>().isInPosition)
            {
                m_AllInPosition = true;
            }
            else
            {
                m_AllInPosition = false;
            }
        }

        if(other.gameObject.tag == "Player" && m_AllInPosition)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            while (audio.isPlaying)
            {

            }
            SceneManager.LoadScene(m_NextLevel);
            Game.current = m_NextLevel;
            SaveLoad.Save();
        }
        else
        {
            other.gameObject.GetComponent<PlayerMovement>().reset();
        }


    }
}
