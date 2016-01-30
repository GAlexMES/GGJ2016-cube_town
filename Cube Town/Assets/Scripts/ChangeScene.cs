using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {

    public string m_changeSzene;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(m_changeSzene);
    }
}
