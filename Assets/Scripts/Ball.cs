using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private Vector3 speed;
    [SerializeField] private string playerTag = "Player";
    [Header("Players")]
    [SerializeField] private Paddle player1;
    [SerializeField] private Paddle player2;

    private Vector3 _currentSpeed, _defaultPosition;
    private bool _canMove;

    void Awake() {
        _canMove = false;
        _defaultPosition = transform.position;
    }
    void Update() {
        if (_canMove) transform.Translate(_currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collission) {
        if (collission.gameObject.CompareTag(playerTag)) {
            _currentSpeed.x *= -1.1f;
        } else {
            _currentSpeed.y *= -1.1f;
        }
    }

    public void ResetBall() {
        _canMove = false;
        transform.position = _defaultPosition;
        Invoke(nameof(StartBall), 1f);
    }

    public void StartBall() {
        _currentSpeed = speed;
        if (!gameObject.activeSelf) gameObject.SetActive(true);
        if (player1.currentPoint > player2.currentPoint) _currentSpeed.x *= -1;
        _canMove = true;
    }

    public void EndGame() {
        _canMove = false;
        transform.position = _defaultPosition;
        gameObject.SetActive(false);
    }
}
