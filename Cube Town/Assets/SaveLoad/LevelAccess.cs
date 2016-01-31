using UnityEngine;
using System.Collections.Generic;

public class LevelAccess : MonoBehaviour {

    private List<string> accessableLevels;
    public string[] levels;
    public bool levelNotSet= true;
    

    // Use this for initialization
    void Start () {
        SaveLoad.Load();
        accessableLevels = SaveLoad.savedGames;

	}
	
	// Update is called once per frame
	void Update () {
        if (levelNotSet)
        {
            foreach (string s in accessableLevels)
            {
                foreach (string level in levels)
                {
                    if (level == s)
                    {
                        Debug.Log(s + " is playable");
                        GameObject.Find(s).GetComponent<MenuTrigger>().m_levelAccessable = true;
                    }
                }
            }
        }
	}
}
