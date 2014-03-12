using UnityEngine;
using System.Collections;

public class SetColor : MonoBehaviour {
	
	public Color newColor;
	
	// Use this for initialization
	void Start () {
		this.renderer.material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
