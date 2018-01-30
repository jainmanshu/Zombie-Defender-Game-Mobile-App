using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't Destroy on Load " + name);
	}

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}
	void OnLevelWasLoaded (int level) {
		AudioClip thislevelMusic = levelMusicChangeArray [level];
		Debug.Log ("Playing Clip " + thislevelMusic);

		if (thislevelMusic) {
			audioSource.clip = thislevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}
