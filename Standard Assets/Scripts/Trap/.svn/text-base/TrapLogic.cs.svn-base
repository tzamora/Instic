using UnityEngine;
using System.Collections;

public class TrapLogic : MonoBehaviour {

	public IsCollidingTrigger isCollidingTrigger;
	public Light spotlight;
	
	public const float MIN_LIGHT_INTENSITY = 0f;
	public const float MAX_LIGHT_INTENSITY = 5f;
	
	// Use this for initialization
	void Start () {
		isCollidingTrigger = this.transform.FindChild("HitCollider").GetComponent<IsCollidingTrigger>();
		spotlight = this.transform.FindChild("Spotlight").GetComponent<Light>();
		spotlight.light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(isCollidingTrigger.isCollidingTrigger){
			//spotlight.light.enabled = true;
			spotlight.light.intensity += 0.02f;
		}
		else{
			//spotlight.light.enabled = false;
			spotlight.light.intensity -= 0.02f;
		}
		
		spotlight.light.intensity = Mathf.Clamp(spotlight.light.intensity, MIN_LIGHT_INTENSITY, MAX_LIGHT_INTENSITY);
	}
}
