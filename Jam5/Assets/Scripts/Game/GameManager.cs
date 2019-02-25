using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static PlayerSpawnData[] playerSpawnData;

    [Header("Settings")]

    [SerializeField]
    private bool doCountdown = false;

    [SerializeField]
    private int playersToEndGame = 1;

    [SerializeField]
    private bool exitToMenu = false;

    [SerializeField]
	private float balloonSpawningIntervalMean = 1f;
	
    [SerializeField]
	private float balloonSpawningIntervalSD = 0.2f;

    [Header("References")]

    [SerializeField]
    private PlayerManager playerManager;
	
	[SerializeField]
	private BalloonSpawner balloonSpawner;

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
		
		for (int n = 0; n < 5; n++)
            balloonSpawner.Spawn(-2f, false);
		
        yield return null;
    }

    private IEnumerator StartGame() {
        yield return new WaitForSeconds(1);
        if (doCountdown) yield return StartCoroutine(countdownController.BeginCountdown());
        cameraController.speed = 0f;
        yield return null;
    }
	
	private float balloonSpawnCooldown = 1.0f;
    private IEnumerator PlayGame() {
        while (playerManager.GetNumPlayersAlive() > playersToEndGame) {
            balloonSpawnCooldown -= Time.fixedDeltaTime;

			if (balloonSpawnCooldown <= 0)
			{
				balloonSpawner.Spawn(Camera.main.transform.localPosition.y - 15);

				float u, v, r;

				do
				{
					u = 2 * Random.value - 1;
					v = 2 * Random.value - 1;
					r = u * u + v * v;
				} while (r <= 0 || r >= 1);

				balloonSpawnCooldown = balloonSpawningIntervalMean + (u * Mathf.Sqrt(-2 * Mathf.Log(r) / r) * balloonSpawningIntervalSD);
			}
			yield return null;
        }
    }

    private IEnumerator EndGame() {
        endGameScreenController.Display();
        yield return new WaitForSeconds(5);
        if (exitToMenu) {
            SceneManager.LoadScene("MainMenu");
        } else {
            SceneManager.LoadScene("Game");
        }
    }

}
