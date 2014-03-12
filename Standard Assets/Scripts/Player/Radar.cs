using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {
	
	private Timer radarTimer;
	private GameObject currentRadarLight;
	
	public GameObject radarPrefab;
	public float radarCooldown;
	
	public int playerNum = -1;
	public Color playerColor;
	
	public bool follow = false;
	
	//Life bar plane
	public GameObject cooldownBar;
	public GameObject score;

	//Plane size control
	public float originalSize = 7;
	private float currentSize;
	
	// Use this for initialization
	void Start () {
		radarTimer = this.gameObject.AddComponent<Timer>();
		if(playerNum != -1){
			//Debug.Log(playerNum);
			cooldownBar = GameObject.Find("CooldownIcons/TexturePlane" + playerNum + "/" + playerNum);
			Material material = new Material(Shader.Find("Self-Illumin/Diffuse"));
	        cooldownBar.renderer.material = material;
		}
	}
	
	bool GetButtonB()
	{
		bool getKey = false;
		
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			getKey = Input.GetKeyDown(KeyCode.JoystickButton17);
		}
		else
		{
			getKey = Input.GetButton("B_" + playerNum);
		}
		
		return getKey;
	}
	
	// Update is called once per frame
	void Update () {
		radarTimer.duration = radarCooldown;
		
		if(playerNum != -1 && GetButtonB() ){
			//Debug.Log("radar!");
	        Radarize();
	    }
		
		if(radarTimer.finished){
			if(currentRadarLight != null){
				Destroy(currentRadarLight);
			}
		}
		
		if(follow && currentRadarLight != null){
			Vector3 tempPos = this.transform.position;
			tempPos.y += 10;
			currentRadarLight.transform.position = tempPos;
		}
		
		//lifeBar.transform.position = this.transform.position;
		//lifeBar.transform.position.y += this.transform.localScale.x;
		//lifeBar.transform.rotation = Quaternion.Euler(Vector3(270,0,0));
		
		currentSize  = originalSize/radarCooldown*radarTimer.currentTime;
		if(cooldownBar){
			cooldownBar.renderer.material.color = playerColor;
			cooldownBar.transform.localScale = new Vector3(currentSize, cooldownBar.transform.localScale.y, cooldownBar.transform.localScale.z);
			score = GameObject.Find("Scores/" + playerNum);
			score.renderer.material.color = playerColor;
		}
	}
	
	public void Radarize(){

		if(radarTimer == null)
		{
			return;
		}	
		
		if(radarTimer.finished){
			if(currentRadarLight != null){
				Destroy(currentRadarLight);
			}
			
			currentRadarLight = (GameObject)(Instantiate(radarPrefab, this.transform.position, Quaternion.Euler(90,0,0)));
			currentRadarLight.light.color = playerColor;
			Vector3 tempPos = this.transform.position;
			tempPos.y += 10;
			currentRadarLight.transform.position = tempPos;
			//currentRadarLight.GetComponent<LightBeat>().repeat = 3;
			//currentRadarLight.GetComponent<LightBeat>().speed = 10;
			currentRadarLight.GetComponent<LightBeat>().Play();
			radarTimer.resetTimer();
		}
	}
}
