using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxPower;
    public Color color {
        get {
            return spriteRenderer.color;
        }
        set {
            spriteRenderer.color = value;
        }
    }

    [Header("Prefabs")]
    [SerializeField]
    private GameObject deathExplosionPrefab;

    new private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Joint2D joint;
    private BalloonString.GrabSlot currentGrabSlot;
    private BalloonString lastGrabbed;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        joint = GetComponent<Joint2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Attach(BalloonString _balloonString, BalloonString.GrabSlot _grabSlot) {

        // Ignore if this was the last balloon we grabbed onto
        if (lastGrabbed == _balloonString) return;

        Vector3 newPosition = _grabSlot.transform.position;
        newPosition.z = transform.position.z;

        transform.position = newPosition;
        transform.rotation = _grabSlot.transform.rotation;
        joint.connectedBody = _balloonString.GetComponent<Rigidbody2D>();
        currentGrabSlot = _grabSlot;
        joint.enabled = true;
        lastGrabbed = _balloonString;

    }

    public void ReleaseBalloonString() {
        if (currentGrabSlot != null) {
            currentGrabSlot.playerInUse = null;
            currentGrabSlot = null;
            joint.connectedBody = null;
            joint.enabled = false;
        }
    }

    public void Jump(Vector2 _direction, float _powerScale) {

        // Join only enabled when are grabbing a balloon string
        if (joint.enabled) {
            ReleaseBalloonString();
        }

        _direction = _direction.normalized;
        float power = maxPower * _powerScale;

        rigidbody.AddForce(_direction * power, ForceMode2D.Impulse);

    }

    public void Die() {
        DeathExplosion deathExplosion = Instantiate(deathExplosionPrefab).GetComponent<DeathExplosion>();
        deathExplosion.transform.position = this.transform.position;
        deathExplosion.SetColor(color);
        Destroy(this.gameObject);
    }

}
