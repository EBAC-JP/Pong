using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI highscorePlayer;
    public static Highscore instance;


    void Awake() {
        instance = this;
    }

    void OnEnable() {
        UpdateText();    
    }

    void UpdateText() {
        highscorePlayer.text = PlayerPrefs.GetString("Highscore", "No Highscore");
    }

    public void SetPlayerWin(string playerName) {
        PlayerPrefs.SetString("Highscore", playerName);
        UpdateText();
    }
}
