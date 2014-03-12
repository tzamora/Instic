using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {

	private Timer attackTimer;
	private Timer punishmentTimer;
	private IsCollidingTrigger colliderScript;
	
	public float attackCooldown;
	public float punishmentTime;
	
	public GameObject deathParticles;
	
	public Color playerColor;
	
	public int playerNum = -1;
	
	private SoundManager soundManager;
	
	// Use this for initialization
	void Start(){
		colliderScript = this.transform.FindChild("HitCollider").GetComponent<IsCollidingTrigger>();
		colliderScript.AddFilteringLayer("Player");
		
		attackTimer = this.gameObject.AddComponent<Timer>();
		punishmentTimer = this.gameObject.AddComponent<Timer>();
		
		soundManager = (SoundManager) FindObjectOfType(typeof( SoundManager ));
	}
	
	bool getButtonA()
	{
		bool getKey = false;
		
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			getKey = Input.GetKeyDown(KeyCode.JoystickButton16);
		}
		else
		{
			getKey = Input.GetButton("A_" + playerNum);
		}
		
		return getKey;
	}
	
	// Update is called once per frame
	void Update(){
		//Needs to be changed to current controller attack key.
		if(playerNum != -1 && getButtonA()){
			//Debug.Log("golpe!");
	        Attack();
	    }
		
		if(!attackTimer.finished){
			//Debug.Log("Attack timer current time:" + attackTimer.currentTime);
		}
		
		if(!punishmentTimer.finished){
			//Debug.Log("Punisment timer current time:" + punishmentTimer.currentTime);
			//this.rigidbody.velocity = new Vector3(0,0,0);
			this.GetComponent<Radar>().follow = true;
		}
		else{
			this.GetComponent<Radar>().follow = false;
		}
		
		attackTimer.duration = attackCooldown;
		punishmentTimer.duration = punishmentTime;
	}
	
	void Attack(){
		if(attackTimer.finished){
			this.transform.FindChild("Esfera_cuchillas").animation.Play();
			
			if(colliderScript.who != null && colliderScript.isCollidingTrigger){
				//Debug.Log("KILL! " + colliderScript.who.gameObject.name);
				GameObject particles = (GameObject)Instantiate(deathParticles, colliderScript.who.transform.position, Quaternion.Euler(0,90,0));
				particles.particleSystem.startColor = playerColor;
				
				Movement killedScript = colliderScript.who.gameObject.GetComponent<Movement>();
				
				soundManager.PlaySound(1);
				
				if(killedScript != null){
				
					GameObject temp = GameObject.Find("Orchestrator");
					
					GameController temp2 = temp.GetComponent<GameController>();
					
					temp2.AddKill(this.playerNum - 1, killedScript.playerNum - 1);
					
					PlayerManager playerManager = (PlayerManager) FindObjectOfType(typeof(PlayerManager));
				
					playerManager.respawnPlayer( killedScript.playerNum - 1 );
					
					killedScript.Die();
					
					//
					// dont detroy the another gameobject we will recicle it for respawn
					//
					
					// Destroy(colliderScript.who.gameObject);
					
					// colliderScript.who = null;
					
					// colliderScript.isCollidingTrigger = false;
				}

			}
			else{
				
				//
				// agregar el componente de radar 
				// y darle play
				//
				
				Radar radar = gameObject.GetComponent<Radar>();
				
				if(radar == null)
				{
					radar = (Radar) gameObject.AddComponent("Radar");
				}
				
				radar.Radarize();

				punishmentTimer.resetTimer();
			}

			attackTimer.resetTimer();
		}
	}
}
