using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	public float duration = 0.0f;
	public float currentTime = 0f;
	public bool finished = true;
	
	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
		if(currentTime > 0){
			currentTime = currentTime - Time.deltaTime;
		}
		
		if(currentTime <= 0){
			finished = true;
		}
		else{
			finished = false;
		}
	}
	
	public void resetTimer(){
		currentTime = duration;
		finished = false;
	}
}



