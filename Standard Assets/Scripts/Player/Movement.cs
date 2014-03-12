using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public string hilerita = "";
	public float speed = 10.0F;
	private AudioSource asrc;
	private const float SPEED_MODIFIER = 2.0f;
	
	public int playerNum = -1;
	public bool movementEnabled = true;
	
	private string inputXAxis = "";
	
	private string inputYAxis = "";
 
	void Start()
	{
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
    		inputXAxis = "Horizontal";
			
			inputYAxis = "Vertical";
		}
		else
		{
			inputYAxis = "L_YAxis_" + playerNum;
			
			inputXAxis = "L_XAxis_" + playerNum;
		}
		
		//Debug.Log ( inputYAxis + "  - 00 -  " + inputXAxis );
	}
	
	public void Die(){
		this.GetComponent<ForceFeedback>().VibrateDie();
	}
	
	bool getButtonX()
	{
		bool getKey = false;
		
		if (Application.platform == RuntimePlatform.OSXEditor)
		{
			getKey = Input.GetKeyDown(KeyCode.JoystickButton18);
		}
		else
		{
			getKey = Input.GetButton("X_" + playerNum);
		}
		
		return getKey;
	}
	
	void Update() {
		
		float modifier = 1f;
		
		if(this.transform.position.y > 1.7){
			this.rigidbody.velocity += new Vector3(0f, -5f, 0f);
		}
		
		if(getButtonX()){
			modifier = SPEED_MODIFIER;
		}
		
		if(movementEnabled && playerNum != -1){
			
	        float velocityX = Input.GetAxis( inputYAxis ) * speed * modifier;
			
	        float velocityY = Input.GetAxis( inputXAxis ) * speed * modifier;
			
			velocityX *= Time.deltaTime;
        	velocityY *= Time.deltaTime;
		
        	this.rigidbody.velocity += new Vector3(-velocityX, 0, -velocityY);
		}
	}
}
	
