using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

	public static List<string> savedGames = new List<string>();
    private static string dashActivatingLevel = "level_8";
			
	//it's static so we can call it from anywhere
	public static void Save() {
        if (!savedGames.Contains(Game.current))
        {
            SaveLoad.savedGames.Add(Game.current);
        }

            BinaryFormatter bf = new BinaryFormatter();
            Debug.Log("save file location: " + Application.persistentDataPath);
            FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        
	}	
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.savedGames = (List<string>)bf.Deserialize(file);
			file.Close();
		}
	}

    private static void checkDash()
    {
        if (savedGames.Contains(dashActivatingLevel))
        {
            Game.allowDash = true;
        }
    }
}
