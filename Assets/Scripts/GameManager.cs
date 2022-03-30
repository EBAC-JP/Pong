using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle player1;
    [SerializeField] private PaddleColor player1Color;
    [SerializeField] private Paddle player2;
    [SerializeField] private PaddleColor player2Color;
    [SerializeField] private TextMeshProUGUI press;
    [SerializeField] private TextMeshProUGUI pressRestart;
    [SerializeField] private GameObject P1NameInput;
    [SerializeField] private GameObject P2NameInput;
    [SerializeField] private GameObject highscore;
    public static GameManager instance;

    public int scoreToEnd;

    void Awake() {
        instance = this;
    }

    public void MenuGame() {
        press.gameObject.SetActive(true);
        P1NameInput.SetActive(true);
        P2NameInput.SetActive(true);
        highscore.SetActive(true);
        player1Color.gameObject.SetActive(true);
        player2Color.gameObject.SetActive(true);
        player1.score.gameObject.SetActive(false);
        player1.wonText.gameObject.SetActive(false);
        player2.score.gameObject.SetActive(false);
        player2.wonText.gameObject.SetActive(false);
    }

    public void StartGame() {
        player1Color.gameObject.SetActive(false);
        player2Color.gameObject.SetActive(false);
        press.gameObject.SetActive(false);
        pressRestart.gameObject.SetActive(false);
        P1NameInput.SetActive(false);
        P2NameInput.SetActive(false);
        highscore.SetActive(false);
        player1.score.gameObject.SetActive(true);
        player2.score.gameObject.SetActive(true);
    }

    public void RestartGame() {
        ball.StartBall();
        player1.StartPaddle();
        player2.StartPaddle();
    }

    public void ResetPosition() {
        ball.ResetBall();
    }

    public void EndGame() {
        pressRestart.gameObject.SetActive(true);
        ball.EndGame();
        player1.EndGame();
        player2.EndGame();
    }
}
