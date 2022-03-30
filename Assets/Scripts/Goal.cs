using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField] string ballTag = "Ball";
    [SerializeField] Paddle player;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag(ballTag)) {
            player.AddPoint();
            if (player.currentPoint >= GameManager.instance.scoreToEnd) StateMachine.instance.ChangeStateToEnd(player.gameObject);
            else StateMachine.instance.ChangeStateToReset();
        }
    }

}
