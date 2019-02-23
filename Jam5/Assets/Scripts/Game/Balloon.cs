using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float buoyancy;
    public float buoyancyFactor = 0.5f;
    public Color color {
        get {
            return spriteRenderer.color;
        }
        set {
            spriteRenderer.color = value;
        }
    }

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
    }

    private void FixedUpdate()
    {
        if (transform.position.y > Camera.main.transform.position.y + 20f || transform.position.y < Camera.main.transform.position.y - 50f)
            spawner.Recycle(transform.parent);
        else
            rigidbody.AddForce(Vector2.up * buoyancy * Time.fixedDeltaTime);
    }
}
