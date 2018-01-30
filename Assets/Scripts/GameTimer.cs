using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float levelSeconds = 100f; 
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private Slider slider;
	private LevelManager levelManager;
	private GameObject winLabel;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		FindYouWin ();
		winLabel.SetActive (false);

	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please Creare you win Object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		print ("Level Over");
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	// Destroy all objects with destroyOnWin tag
	void DestroyAllTaggedObjects() {
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		foreach (GameObject taggedObject in taggedObjectArray) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel () {
		levelManager.LoadNextLevel ();
	}
}
