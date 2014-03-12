using UnityEngine;
using System.Collections;

public class PingPong : MonoBehaviour {
	
	private Vector3 originalPosition;
	public float speed;
	private bool twoStep = false;
	
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Mathf.PingPong(Time.time * speed, 2f);
		
		if(offset > 1.95 && !twoStep){
			speed = 5;
			twoStep = !twoStep;
		}
		else if(offset > 1.95 && twoStep){
			speed = 1;
			twoStep = !twoStep;
		}
		
		offset -= 1;
		this.transform.position = new Vector3(originalPosition.x + (offset * 5), originalPosition.y, originalPosition.z);
		Debug.Log("ping pong value" + offset);
	}
}
