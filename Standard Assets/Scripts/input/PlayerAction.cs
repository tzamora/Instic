using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	
	public float speed = 10f;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Move( Vector3 move )
	{
		transform.Translate( move * speed * Time.deltaTime );
	}
}
