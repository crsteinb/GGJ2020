using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	[Range(0f, 1f)]
	public float volume = 1f;

	public Sound[] sounds;

	public static AudioManager instance;

	// Use this for initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			// s.source.volume = (volume * s.volume) / 2;
			s.source.volume = volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	
	public void Play (string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = volume;
		s.source.Play();
	}

	public void Stop (string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);

		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = volume;
		s.source.Stop();
	}

	public void SetVolume (float newVolume) {
		volume = newVolume;
	}
	
}
