using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnees;

    public void RandomSpawn(Vector3 position)
    {
        Instantiate(spawnees[Random.Range(0, spawnees.Length)], position, Quaternion.identity, transform);
    }
}
