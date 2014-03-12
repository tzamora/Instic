using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public AudioClip[] sounds;
	
	public AudioClip currentSound;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlaySound(int soundID)
	{
		currentSound = (AudioClip) sounds[soundID];
		
		AudioSource.PlayClipAtPoint(currentSound, transform.position);
	}
}
