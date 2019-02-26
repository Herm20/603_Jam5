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

    [SerializeField]
    private int initialNumBalloons = 10;

    [SerializeField][Range(0, 20)]
    private float itemSpawnFrequency = 10;

    [SerializeField]
    [Range(0, 1)]
    private float itemSpawnFrequencyIncrease = 0.1f;

    [SerializeField]
    [Range(0, 20)]
    private float obstacleSpawnFrequency = 10;

    [SerializeField][Range(0, 1)]
    private float obstacleSpawnFrequencyIncrease = 0.5f;

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

    [SerializeField]
    private RandomSpawner itemSpawner;

    [SerializeField]
    private RandomSpawner obstacleSpawner;

    [SerializeField]
    private GameObject selectObj;

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
        selectObj.SetActive(true);
        while (!Input.GetButtonDown("StartButton"))
        {
            yield return null;
        }
    }

    private IEnumerator StartGame() {
        yield return new WaitForSeconds(1);
        if (doCountdown) yield return StartCoroutine(countdownController.BeginCountdown());
        cameraController.speed = 2f;
        selectObj.SetActive(false);

        for (int n = 0; n < initialNumBalloons; n++)
            balloonSpawner.Spawn(Random.Range(-5f, 0f), false);

        yield return null;
    }
	
	private float balloonSpawnCooldown = 1.0f;
    private IEnumerator PlayGame() {
        while (playerManager.GetNumPlayersAlive() > playersToEndGame) {
            balloonSpawnCooldown -= Time.deltaTime;

            if (balloonSpawnCooldown <= 0)
			{
				balloonSpawner.Spawn(Camera.main.transform.localPosition.y - 20);

				float u, v, r;

				do
				{
					u = 2 * Random.value - 1;
					v = 2 * Random.value - 1;
					r = u * u + v * v;
				} while (r <= 0 || r >= 1);

				balloonSpawnCooldown = balloonSpawningIntervalMean + (u * Mathf.Sqrt(-2 * Mathf.Log(r) / r) * balloonSpawningIntervalSD);
			}

            if (Random.Range(0, 10000) < itemSpawnFrequency)
                itemSpawner.RandomSpawn(new Vector3(Random.Range(-20f, 20f), Camera.main.transform.localPosition.y + 15, 0));

            if (Random.Range(0, 10000) < obstacleSpawnFrequency)
                obstacleSpawner.RandomSpawn(new Vector3(Random.Range(-20f, 20f), Camera.main.transform.localPosition.y + Random.Range(15f, 30f), 0));

            itemSpawnFrequency += itemSpawnFrequencyIncrease * Time.deltaTime;
            obstacleSpawnFrequency += obstacleSpawnFrequencyIncrease * Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator EndGame() {
        foreach (GameObject gObj in playerManager.playerObjs)
        {
            if (gObj != null)
            {
                endGameScreenController.SetWinner(gObj.GetComponent<PlayerController>());
            }
        }
        endGameScreenController.Display();
        
        for (int i = 0; i < 4; i++)
        {
            playerManager.readyUp[i] = false;
        }
        yield return new WaitForSeconds(5);
        if (exitToMenu) {
            SceneManager.LoadScene("MainMenu");
        } else {
            SceneManager.LoadScene("Game");
        }
    }

}
