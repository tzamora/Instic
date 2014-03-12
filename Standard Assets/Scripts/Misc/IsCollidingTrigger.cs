using UnityEngine;
using System.Collections;

public class IsCollidingTrigger : MonoBehaviour {
	
	public bool isCollidingTrigger = false;
	public Collider who;
	
	private string layer;
	
	void OnTriggerStay (Collider other){
		isCollidingTrigger = true;
		if(other.gameObject.layer == LayerMask.NameToLayer(layer)){
			who = other;
		}
	}

	void OnTriggerExit (Collider other){
		isCollidingTrigger = false;
		who = null;
	}
	
	public void AddFilteringLayer(string layerName){
		layer = layerName;
	}
	
}