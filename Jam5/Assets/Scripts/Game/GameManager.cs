using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static PlayerSpawnData[] playerSpawnData;

    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private CameraController cameraController;

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
        cameraController.speed = 2f;
        yield return null;
    }

    private IEnumerator PlayGame() {
        while (true) {
            yield return null;
        }
    }

    private IEnumerator EndGame() {
        yield return null;
    }

}
