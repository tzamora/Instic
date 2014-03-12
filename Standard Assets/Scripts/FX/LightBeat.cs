using UnityEngine;
using System.Collections;

public class LightBeat : MonoBehaviour {

	public Light newLight;
	
	float spotAngle = 0;
	
	float startTime = 0;
	
	float elapsedTime = 0;
	
	bool firstPhase = true;
	
	bool secondPhase = false;
	
	public int repeat = 4;
	
	public float speed = 1f;
	
	private int timesRepeating = 0;
	
	private bool playing = true;
	
	// Use this for initialization
	void Start () {
	
		newLight = GetComponent<Light>();
		newLight.spotAngle = 0;
		
		if(newLight == null)
		{
			Debug.Log("Light component is required for this script");
		}
		
		startTime = Time.time;
		
		
	}

	// Update is called once per frame
	void Update () {
	
		if(playing)
		{
			beatEffect();
		}
	}
	
	public void Play()
	{
		if(newLight != null)
		{
			newLight.enabled = true;
			playing = true;
		}

	}
	
	void beatEffect()
	{
		/*if(fourthPhase)
		{
			spotAngle = Mathf.Lerp(100f, 0f, elapsedTime );

		}
		
		if(thirdPhase)
		{
			spotAngle = Mathf.Lerp(80f, 100f, elapsedTime );
			
			if(spotAngle >= 100)
			{
				startTime = Time.time;
				
				thirdPhase = false;
				
				fourthPhase = true;
			}
		}*/
		
		if(secondPhase)
		{
			spotAngle = Mathf.Lerp(100f, 0f, elapsedTime );
			
			//Debug.Log("  --  " + timesRepeating);
			
			
			if(spotAngle <= 0)
			{
				timesRepeating++;
				
				//
				// restart the time
				//
				
				startTime = Time.time;
				
				elapsedTime = 0;
				
				firstPhase = true;
				
				secondPhase = false;
			}
			
			if(timesRepeating >= repeat )
			{	
				firstPhase = false;
				
				secondPhase = false;
				
				newLight.enabled = false;
			}
		}
		
		if(firstPhase)
		{
			spotAngle = Mathf.Lerp(0f, 100f, elapsedTime );
			
			if(spotAngle >= 100)
			{
				//
				// restart the time
				//
				
				startTime = Time.time;
				
				firstPhase = false;
				
				secondPhase = true;
			}
		}
		
		if(firstPhase || secondPhase)
		{
		
			newLight.spotAngle = spotAngle;
			
			//
			// make it faster
			//
			
			elapsedTime = (Time.time - startTime) * speed;
		}
	}
	
}
