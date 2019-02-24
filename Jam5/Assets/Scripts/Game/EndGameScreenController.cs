using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreenController : MonoBehaviour {

    [SerializeField]
    private Text winnerText;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(true);
	}

    public void SetWinner(PlayerController _playerController) {
        Color c = Color.white;
        string winnerNumber = "?";
        if (_playerController != null) {
            // TODO: Implement player numbers (Wait for Herman)
            //winnerName = SOMETHING
        }
        winnerText.text = "PLAYER " + winnerNumber + " WINS";
        winnerText.color = _playerController.color;
    }

    public void Display() {
        this.gameObject.SetActive(true);
    }

}
