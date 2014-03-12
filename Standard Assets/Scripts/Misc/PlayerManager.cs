using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
	
	public GameObject playerPrefab;
	public List<Color> posibleColors;
	public int numberPlayers = 1;
	private bool[] respawnsTaken;
	private bool[] colorsTaken;
	private GameObject[] players = new GameObject[4];
	
	
	private StartGameManager startGameManager;
	
	// Use this for initialization
	void Start () {
		
		//
		// retrieve the start game manager to get the number of players
		//
		
		startGameManager = (StartGameManager) FindObjectOfType(typeof( StartGameManager ));
		
		if(startGameManager != null)
		{
			numberPlayers = startGameManager.numberOfPlayers;
		}
		
		CreatePlayers();
		DisableRespectiveBars();
		DisableRespectiveScores();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void CreatePlayer(int controller, Color color, Vector3 position){
		GameObject player = (GameObject)Instantiate(playerPrefab, position, Quaternion.identity);
		player.GetComponent<ForceFeedback>().playerNum = controller;
		player.GetComponent<Movement>().playerNum = controller;
		player.GetComponent<Radar>().playerNum = controller;
		player.GetComponent<Radar>().playerColor = color;
		player.GetComponent<Attacking>().playerNum = controller;
		player.GetComponent<Attacking>().playerColor = color;
		//player.renderer.material.color = color;
		player.transform.FindChild("Esfera_cuchillas").transform.FindChild("Esfera Ataque").renderer.material.color = color;
		
		players[controller - 1] = player;
	}
	
	void CreatePlayers(){
		
		numberPlayers = Mathf.Clamp(numberPlayers, 1, 4);
		
		InitializeTaken();
		
		for(int i = 0; i < numberPlayers; i++){
			CreatePlayer(i + 1, GetRandomColor(), GetRandomPosition());
		}
	}
	
	void DisableRespectiveBars(){
		for(int i = numberPlayers + 1; i <= 4; i++){
			GameObject.Find("CooldownIcons/TexturePlane" + i).SetActive(false);
		}
	}
	
	void DisableRespectiveScores(){
		for(int i = numberPlayers + 1; i <= 4; i++){
			GameObject.Find("Scores/" + i).SetActive(false);
		}
	}
	
	private void InitializeTaken(){
		respawnsTaken = new bool[GameObject.Find("RespawnPositions").transform.GetChildCount()];
		colorsTaken = new bool[posibleColors.Count];
	}
	
	private Vector3 GetRandomPosition(){
		int positionChosen;
		do {
			positionChosen = Random.Range(0, respawnsTaken.Length);
		} while (respawnsTaken[positionChosen] != false);
		
		respawnsTaken[positionChosen] = true;
		
		return GameObject.Find("RespawnPositions").transform.GetChild(positionChosen).transform.position;
	}
	
	private Color GetRandomColor(){
		int positionChosen;
		do {
			positionChosen = Random.Range(0, posibleColors.Count);
		} while (colorsTaken[positionChosen] != false);
		
		colorsTaken[positionChosen] = true;
		
		return posibleColors[positionChosen];
	}
	
	public void respawnPlayer(int playerController)
	{
		respawnsTaken[ Random.Range(0, 5) ] = false;
		
		Vector3 respawnPosition = GetRandomPosition();
		
		GameObject player = (GameObject) players[playerController];
		
		//Debug.Log( " ))) " + playerController );
		
		if(player != null)
		{
			player.transform.position = respawnPosition;
		}
	}
	
}
