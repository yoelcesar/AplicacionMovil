using UnityEngine;
using System.Collections;

public class CargarHighscore : MonoBehaviour {
	
	public TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		textMesh.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString("D5");
	}
}
