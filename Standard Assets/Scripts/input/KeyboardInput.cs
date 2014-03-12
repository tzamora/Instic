using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	
	private PlayerAction player;
	
	Vector3 move;
	
	// Use this for initialization
	void Start () {
	
		player = GetComponent<PlayerAction>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		move = Vector3.zero;
		
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			move = Vector3.left;
		}
		
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			move = Vector3.right;
		}
		
		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			move = Vector3.up;
		}
		
		if( Input.GetKey( KeyCode.DownArrow ) )
		{
			move = Vector3.down;
		}
		
		player.Move( move );
	}
}
