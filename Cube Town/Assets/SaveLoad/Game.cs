using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Game { //don't need ": Monobehaviour" because we are not attaching it to a game object

    public static bool allowDash = false;
	public static string current;
    public List<string> freeLevels = new List<string>();


	public Game () {
        freeLevels.Add("level_1");
        allowDash = false;
	}
		
}
