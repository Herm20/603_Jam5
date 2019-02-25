using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private Transform balloonPrefab;
    [SerializeField] private Vector2 spawningRangeX;

    LinkedList<Transform> reusableBalloons = new LinkedList<Transform>();

    public void Spawn(float height, bool applyInitialForce = true)
    {
        Transform balloon;

        if (reusableBalloons.Count == 0)
            balloon = Instantiate(balloonPrefab, transform);
        else
        {
            balloon = reusableBalloons.First.Value;
            balloon.gameObject.SetActive(true);

            reusableBalloons.RemoveFirst();
        }

        float size = Random.value + 1;
        float x = Random.Range(spawningRangeX.x, spawningRangeX.y);

        balloon.transform.localPosition = new Vector3(x, height, 0);
        balloon.transform.localScale = Vector3.one * size;
        balloon.GetComponentInChildren<Balloon>().Initialize(this, size, applyInitialForce);
    }

    public void Recycle(Transform balloon)
    {
        Destroy(balloon.gameObject);

        // reusableBalloons.AddLast(balloon);
    }
}
