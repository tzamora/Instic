using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public AudioSource asrc;
	public List<AudioClip> soundList; 
	
	// Use this for initialization
	void Start () {
		asrc = GetComponent(typeof(AudioSource)) as AudioSource;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
			Debug.Log("Choque con otro hijueputa");
			this.GetComponent<AudioSource>().audio.clip = soundList[1];
		}
		else{
			this.GetComponent<AudioSource>().audio.clip = soundList[0];
		}
		
		if(asrc != null)
		{
			asrc.Play();
		}
	}
}


