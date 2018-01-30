using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fadein : MonoBehaviour {

	public float fadeInTime;

	private Image fadepanel;
	private Color currentColor = Color.black;
	// Use this for initialization
	void Start () {
		fadepanel = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadepanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}
}
