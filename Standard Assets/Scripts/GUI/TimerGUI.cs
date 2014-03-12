using UnityEngine;
using System.Collections;

public class TimerGUI : MonoBehaviour {
	
	public TextMesh gameOverText;
	
	TextMesh textMesh;
	
	public float gameDuration;
	public float gameOverDuration;
	
	Timer timer;
	
	// Use this for initialization
	void Start () {
	
		textMesh = GetComponent<TextMesh>();
		
		timer = GetComponent<Timer>();
		
		timer.duration = gameDuration;
		
		timer.resetTimer();
	}
	
	// Update is called once per frame
	void Update () {
	
		textMesh.text = "Timer: " + timer.currentTime.ToString("f1");
		
		if( timer.finished )
		{
			ShowGameOver();
		}
	}
	
	void ShowGameOver()
	{	
		gameOverText.gameObject.renderer.enabled = true;
		
		Invoke( "GoBackToMenu", gameOverDuration );
	}
	
	void GoBackToMenu()
	{
		Application.LoadLevel("Carreta.StartMenu");
	}
}
