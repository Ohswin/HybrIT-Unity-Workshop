using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource EffectsSource;
	AudioSource MusicSource;

	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	public static AudioManager Instance = null;
	
	private void Awake() {
		if (Instance == null) {
			Instance = this;
			MusicSource = GetComponent<AudioSource>();
		} else if (Instance != this) {
            Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public static void PlayEffect(AudioClip clip) {
		Instance.EffectsSource.clip = clip;
		Instance.EffectsSource.Play();
	}

	public static void StopMusic() {
		Instance.MusicSource.Stop();
	}

	public static void PlayMusic(AudioClip clip) {
		Instance.MusicSource.Stop();
		Instance.MusicSource.clip = clip;
		Instance.MusicSource.Play();
	}

	public void RandomSoundEffect(params AudioClip[] clips) {
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}
}