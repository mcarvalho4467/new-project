using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

	public float sensitivity = 100f;
	public float loudness = 0f;

	private AudioSource audio;

	void Start () 
	{
		audio = GetComponent<AudioSource> ();
		audio.clip = Microphone.Start (null, true, 10, 44100);
		audio.loop = true;
		audio.mute = true;
		while (!(Microphone.GetPosition (null) > 0)) { }
		audio.Play ();
	}

	void Update () 
	{
		loudness = GetAverageVolume () * sensitivity;
		if (loudness > 8)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (this.GetComponent<Rigidbody2D> ().velocity.x, 4);
	}

	public float GetAverageVolume ()
	{
		float [] data = new float [256];
		float a = 0;
		audio.GetOutputData (data, 0);

		foreach (float s in data) 
		{
			a+= Mathf.Abs(s);
		}

		return a / 256;
	}
}
