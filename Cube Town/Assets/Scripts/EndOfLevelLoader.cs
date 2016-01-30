using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelLoader : MonoBehaviour {
    public string m_NextLevel;

    void Start()
    {
        Game.current = SceneManager.GetActiveScene().name;
    }
    

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("save " + Game.current);
            SaveLoad.Save();
            SceneManager.LoadScene(m_NextLevel);
        }
    }
}
