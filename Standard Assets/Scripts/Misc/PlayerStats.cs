using UnityEngine;
using System.Collections;

public class PlayerStats {
	
	public int deaths = 0;
		
	public int kills = 0;
	
	public override string ToString() 
	{
		string ds = deaths.ToString();
		string ks = kills.ToString();
		return "Deaths: " + ds + " " + "Kills: " + ks;
	}
}
