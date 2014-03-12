using UnityEngine;
using System.Collections;

public class GamePadInput : MonoBehaviour {
	
	private PlayerAction player;
	
	private Vector3 move;
	
	// Use this for initialization
	void Start () {
	
		player = GetComponent<PlayerAction>();
		
		move = Vector3.zero;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float horizontalAxis = Input.GetAxis("HorizontalJoystick");
		
		Debug.Log( " - > " + horizontalAxis );
		
		move = new Vector3( horizontalAxis, 0f, 0f ); 
		
		player.Move( move );
		
	}
}
