using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform[] spawnPositions;

    public void SpawnPlayers(PlayerSpawnData[] _psd) {
        if (_psd == null || _psd.Length == 0) return;
        for (int i = 0; i <_psd.Length; i++) {
            PlayerSpawnData spawnData = _psd[i];
            GameObject playerObj = Instantiate(playerPrefab);
            PlayerController playerController = playerObj.GetComponent<PlayerController>();
            playerObj.transform.position = spawnPositions[i % spawnPositions.Length].position;
            playerController.color = spawnData.color;
        }
    }

}

public class PlayerSpawnData {
    public Color color;
}