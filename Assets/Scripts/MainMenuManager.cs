using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public TextMesh highScoreText;
	// Use this for initialization
	void Start () {
		highScoreText.text = PlayerPrefs.GetInt ("Highscore").ToString();
        PlayerPrefs.SetInt("CurrentHitScore", 0);
        PlayerPrefs.SetInt("CurrentMissScore", 0);
    }

}
