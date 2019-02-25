using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.Find("GameManager").GetComponent<PlayerManager>();
            return instance;
        }
    }

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform[] spawnPositions;

    public List<GameObject> playerObjs = new List<GameObject>();

    public void SpawnPlayers(PlayerSpawnData[] _psd) {

        if (_psd == null || _psd.Length == 0) return;
        
        for (int i = 0; i <_psd.Length; i++) {

            PlayerSpawnData spawnData = _psd[i];
            GameObject playerObj = Instantiate(playerPrefab);

            PlayerController playerController = playerObj.GetComponent<PlayerController>();
            playerObj.transform.position = spawnPositions[i % spawnPositions.Length].position;
            playerController.color = spawnData.color;

            JoystickController joyCon = playerObj.AddComponent<JoystickController>();

            playerObjs[i] = playerObj;
        }
    }

    public void SpawnPlayer(InputData _data, Color _color)
    {
        
        GameObject playerObj = Instantiate(playerPrefab);
        playerObj.name = "PLAYER " + _data.controllerNum;

        PlayerController playerController = playerObj.GetComponent<PlayerController>();
        playerObj.transform.position = spawnPositions[_data.controllerNum - 1].position;
        playerController.color = _color;

        JoystickController joyCon = playerObj.AddComponent<JoystickController>();
        joyCon.inputData = _data;

        playerObjs.Add(playerObj);

    }

    public int GetNumPlayersAlive() {
        int count = 0;
        foreach(GameObject playerObj in playerObjs) {
            if (playerObj != null) {
                count++;
            }
        }
        return count;
    }

}

[Serializable]
public class PlayerSpawnData {
    public Color color;
    public ControllerList playerInput;
}