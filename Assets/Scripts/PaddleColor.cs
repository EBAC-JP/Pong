using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleColor : MonoBehaviour {

    [SerializeField] private Paddle player;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [Header("Color")]
    [SerializeField] private List<Color> colors;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;

    private int _index;
    private bool _onMenu;

    void OnEnable() {
        _onMenu = true;    
    }

    void OnDisable() {
        _onMenu = false;    
    }
    // Update is called once per frame
    void Update() {
        if (PlayerPrefs.GetInt("Typing", 0) == 0 && _onMenu) {
            CheckIndex();
            if (Input.GetKeyDown(upKey) && _index > 0) {
                _index--;
            } else if (Input.GetKeyDown(downKey) && _index < colors.Count - 1) {
                _index++;
            }
            player.ChangeColor(colors[_index]);
        }
    }

    void CheckIndex() {
        if (_index == 0) upArrow.SetActive(false);
        else if(_index == colors.Count - 1) downArrow.SetActive(false);
        else {
            upArrow.SetActive(true);
            downArrow.SetActive(true);
        }
    }
}
