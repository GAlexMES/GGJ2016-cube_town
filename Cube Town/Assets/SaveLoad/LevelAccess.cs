using UnityEngine;
using System.Collections.Generic;

public class LevelAccess : MonoBehaviour {

    private List<string> accessableLevels;

    // Use this for initialization
    void Start () {
        SaveLoad.Load();
        accessableLevels = SaveLoad.savedGames;

	}
	
	// Update is called once per frame
	void Update () {
	    foreach(string s in accessableLevels){
            Debug.Log(s+" is playable");
            GameObject.Find(s).GetComponent<MenuTrigger>().m_levelAccessable = true;
        }
	}
}
