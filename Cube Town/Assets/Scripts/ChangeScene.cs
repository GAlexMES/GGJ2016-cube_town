using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {

    public string m_changeSzene;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Change Scene to:" + m_changeSzene);
        SceneManager.LoadScene(m_changeSzene);
    }
}
