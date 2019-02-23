using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static PlayerSpawnData[] playerSpawnData;

    [Header("Settings")]

    [SerializeField]
    private bool doCountdown = false;

    [SerializeField]
    private int playersToEndGame = 1;

    [Header("References")]

    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private CountdownController countdownController;

    [SerializeField]
    private EndGameScreenController endGameScreenController;

	// Use this for initialization
	void Start () {
        StartCoroutine(GameLoop());
	}

    private IEnumerator GameLoop() {

        yield return StartCoroutine(InitializeGame());

        yield return StartCoroutine(StartGame());

        yield return StartCoroutine(PlayGame());

        yield return StartCoroutine(EndGame());
        
    }

    private IEnumerator InitializeGame() {
        playerManager.SpawnPlayers(playerSpawnData);
        yield return null;
    }

    private IEnumerator StartGame() {
        yield return new WaitForSeconds(1);
        if (doCountdown) yield return StartCoroutine(countdownController.BeginCountdown());
        cameraController.speed = 2f;
        yield return null;
    }

    private IEnumerator PlayGame() {
        while (playerManager.GetNumPlayersAlive() > playersToEndGame) {
            yield return null;
        }
    }

    private IEnumerator EndGame() {
        endGameScreenController.Display();
        yield return null;
    }

}
