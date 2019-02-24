using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float buoyancy;
    public float buoyancyFactor = 1f;
    public Color color {
        get {
            return spriteRenderer.color;
        }
        set {
            spriteRenderer.color = value;
        }
    }
    public float maxYSpeed;

    public Color[] spawnColors;

    new private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    private BalloonSpawner spawner;

    public void Initialize(BalloonSpawner spawner, float size, bool applyInitialForce)
    {
        // transform.localScale = size * Vector3.one;
        buoyancy *= Mathf.Pow(size, buoyancyFactor);

        this.spawner = spawner;

        if (applyInitialForce)
            rigidbody.AddForce(Vector2.up * buoyancy * Time.deltaTime);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = spawnColors[Random.Range(0, spawnColors.Length)];
    }

    private void FixedUpdate()
    {

        if (transform.position.y > Camera.main.transform.position.y + 20f || transform.position.y < Camera.main.transform.position.y - 50f) {
            spawner.Recycle(transform.parent);
        } else {
            rigidbody.AddForce(Vector2.up * buoyancy);
        }

        if (rigidbody.velocity.y > maxYSpeed) {
            Vector3 v = rigidbody.velocity;
            v.y = maxYSpeed;
            rigidbody.velocity = v;
        }

    }
}
