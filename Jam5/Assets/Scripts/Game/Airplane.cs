using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;

    private void Awake()
    {
        direction = direction.normalized;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
	}
}
