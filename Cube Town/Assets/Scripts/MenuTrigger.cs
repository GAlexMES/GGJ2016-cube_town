using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour {

    public bool m_levelAccessable = false;
    public string m_levelScene;
    public Material material;
    GameObject m_cube;
    Renderer render;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && m_levelAccessable)
        {
            SceneManager.LoadScene(m_levelScene);
        }
    }

    // Use this for initialization
    void Start () {
        m_cube = GameObject.Find(m_levelScene);
        if (m_levelAccessable)
        {
            Material newMat = Resources.Load("Green", typeof(Material)) as Material;
            render = GetComponent<Renderer>();
            render.enabled = true;
            render.material = material;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        Start();
	}
}
