using UnityEngine;
using System.Collections;

public class StartGameManager : MonoBehaviour {
	
	public int numberOfPlayers;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake()
	{
		DontDestroyOnLoad( transform.gameObject );
	}
	
	public void StartGame(int numOfPlayers)
	{
		numberOfPlayers = numOfPlayers;
		
		//
		// set the number of player based on the combo selection
		//
		
		Application.LoadLevel ("TestSceneHitting");
	}
}
