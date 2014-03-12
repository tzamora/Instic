using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	Hashtable score;
	
	public GameObject scoreGameobject;
	
	// Use this for initialization
	void Start () {
		score = new Hashtable();
	}
	
	// Update is called once per frame
	void Update () {
		/*Debug.Log("player 1" + GetPlayerStats(0));
		Debug.Log("player 2" + GetPlayerStats(1));*/
	}
	
	public void AddKill(int killer, int deceased)
	{
		PlayerStats killerPlayerStats = GetPlayerStats( killer );
		
		killerPlayerStats.kills += 1;
		
		PlayerStats deceasedPlayerStats = GetPlayerStats( deceased );
		
		deceasedPlayerStats.deaths += 1;
		
		UpdatePlayerScores();
	}
	
	public PlayerStats GetPlayerStats(int player)
	{
		PlayerStats playerStats = (PlayerStats) score[player];
		
		if(playerStats==null)
		{
			playerStats = new PlayerStats();
			
			score[player] = playerStats;
		}
		
		return playerStats;
	}
	
	private void UpdatePlayerScores(){
		for(int i = 1; i <= 4; i++){
			GameObject child = scoreGameobject.transform.FindChild("" + i).gameObject;
			child.GetComponent<TextMesh>().text = GetPlayerStats(i - 1).kills.ToString();
		}
	}
}













