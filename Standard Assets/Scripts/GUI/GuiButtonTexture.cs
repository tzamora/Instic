using UnityEngine;
using System.Collections;

public class GuiButtonTexture : MonoBehaviour {
	
	StartGameManager startGameManager;
	
	public int numberOfPlayers = 0;
	
	// Use this for initialization
	void Start () {
	
		startGameManager = (StartGameManager) FindObjectOfType( typeof ( StartGameManager ) );
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		StartButtonClick();
	}
	
	void StartButtonClick()
	{
		startGameManager.StartGame(numberOfPlayers);	
	}
}
