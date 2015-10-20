using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Save and load the gameState with all the informations like damage, firerate, ...
// it's static so we can call it from anywhere
public static class SaveLoad{

	private static BinaryFormatter bf = new BinaryFormatter ();

	public static void Save() 
	{
		FileStream fs = File.Create (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize(fs, Game.gameState);
		fs.Close();
	}   
	
	public static GameState Load() 
	{
		if (File.Exists (Application.persistentDataPath + "/savedGames.gd")) {
			Stream fs = File.Open (Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			GameState obj = (GameState)bf.Deserialize (fs);
			fs.Close ();
			return obj;
		} 
		else 
		{
			return new GameState();
		}

	}
}