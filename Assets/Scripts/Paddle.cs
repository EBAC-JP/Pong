using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private TMP_InputField playerNameInput;
    [Header("Key Setup")]
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [Header("Points")]
    [SerializeField] public TextMeshProUGUI score;
    public int currentPoint;
    [Header("Winner")]
    [SerializeField] public TextMeshProUGUI wonText;

    private Rigidbody2D _myRigidbody;
    private Vector3 _defaultPositon;
    private bool _canMove;
    private string _playerName;

    void Awake() {
        _myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _canMove = false;
        _playerName = gameObject.name;
        _defaultPositon = transform.position;
        wonText.gameObject.SetActive(false);
    }

    void Update() {
        if (_canMove) {
            if (Input.GetKey(upKey)) {
                _myRigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
            } else if (Input.GetKey(downKey)) {
                _myRigidbody.MovePosition(transform.position + transform.up * -speed * Time.deltaTime);
            }
        }
    }

    void ResetPoints() {
        currentPoint = 0;
        score.text = currentPoint.ToString();
    }

    public void ChangeColor(Color newColor) {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    public void AddPoint() {
        currentPoint++;
        score.text = currentPoint.ToString();
    }

    public void StartPaddle() {
        wonText.gameObject.SetActive(false);
        ResetPoints();
        _canMove = true;
    }

    public void PlayerWon() {
        wonText.text = _playerName + "\n WON";
        wonText.gameObject.SetActive(true);
        Highscore.instance.SetPlayerWin(_playerName);
    }

    public void EndGame() {
        _canMove = false;
        transform.position = _defaultPositon;
    }

    public void IsTyping() {
        PlayerPrefs.SetInt("Typing", 1);
    }

    public void NotTyping() {
        PlayerPrefs.SetInt("Typing", 0);
        _playerName = playerNameInput.text;
    }
}
