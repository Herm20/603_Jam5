using UnityEngine;

public class FanArea : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction;

    [SerializeField]
    private float maxDistanceOfEffect = 10f;

    [SerializeField]
    private float maxPower = 10000f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Balloon"))
            collision.GetComponent<Rigidbody2D>().AddForce(direction * maxPower * Time.deltaTime * Mathf.Max(0, 1 - Vector3.Magnitude(transform.position - collision.transform.position) / maxDistanceOfEffect));
    }

    private void Awake()
    {
        direction = direction.normalized;
    }
}
