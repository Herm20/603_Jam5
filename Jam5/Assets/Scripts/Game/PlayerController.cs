using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Settings")]

    [SerializeField]
    private int numJumps = 1;
    public int jumpsRemaining;

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

    private Item item = null;

    private Vector3 frozenPos;
    private float frozenTime = 0.0f;
    private Vector3 jetpackForce = new Vector3(0.0f, 2000.0f, 0.0f);
    private float jetpackTime = 0.0f;

    [Header("Reference")]
    public Transform arrow;
    public SpriteRenderer arrowSprite;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        joint = GetComponent<Joint2D>();
    }

    // Use this for initialization
    void Start () {
        jumpsRemaining = numJumps;
    }
	
	// Update is called once per frame
	void Update () {
        if (frozenTime > 0.0f) {
            transform.position = frozenPos;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.angularVelocity = 0.0f;
            frozenTime -= Time.deltaTime;

            return;
        }
        if (jetpackTime > 0.0f) {
            jetpackTime -= Time.deltaTime;
            rigidbody.AddForce(jetpackForce * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public bool IsGrabbingBalloonString() {
        return currentGrabSlot != null;
    }

    public void Attach(BalloonString _balloonString, BalloonString.GrabSlot _grabSlot) {
        // Ignore if this was the last balloon we grabbed onto
        if (lastGrabbed == _balloonString) return;

        if (frozenTime > 0.0f) return;

        Vector3 newPosition = _grabSlot.transform.position;
        newPosition.z = transform.position.z;

        transform.position = newPosition;
        transform.rotation = _grabSlot.transform.rotation;
        joint.connectedBody = _balloonString.GetComponent<Rigidbody2D>();
        currentGrabSlot = _grabSlot;
        joint.enabled = true;
        lastGrabbed = _balloonString;

        jumpsRemaining = numJumps;
    }

    public void GetItem(Item _item)
    {
        if (frozenTime > 0.0f) return;

        if (item != null) return;

        _item.gameObject.transform.position = new Vector3(0, 0, 0);
        _item.gameObject.transform.rotation = Quaternion.identity;

        _item.transform.SetParent(transform, false);
        
        item = _item;
    }

    public void ReleaseBalloonString() {
        if (IsGrabbingBalloonString()) {
            currentGrabSlot.playerInUse = null;
            currentGrabSlot = null;
            joint.connectedBody = null;
            joint.enabled = false;
        }
    }

    public void Jump(Vector2 _direction, float _powerScale) {
        if (frozenTime > 0.0f) return;

        if (_direction == Vector2.zero || _powerScale == 0) return;

        if (jumpsRemaining <= 0) return;
        jumpsRemaining--;

        // Join only enabled when are grabbing a balloon string
        if (joint.enabled) {
            ReleaseBalloonString();
        }

        _direction = _direction.normalized;
        float power = maxPower * _powerScale;

        rigidbody.AddForce(_direction * power, ForceMode2D.Impulse);

    }

    public void Use(Vector2 _direction)
    {
        if (frozenTime > 0.0f) return;

        if (item != null)
        {
            item.Use(_direction);

            Destroy(item.gameObject);
            item = null;
        }
    }

    public void Freeze()
    {
        if (joint.enabled)
        {
            ReleaseBalloonString();
        }

        frozenPos = transform.position;
        frozenTime = 3.0f;
    }

    public void GetJet()
    {
        jetpackTime = 1.25f;
    }

    public void Die() {
        DeathExplosion deathExplosion = Instantiate(deathExplosionPrefab).GetComponent<DeathExplosion>();
        deathExplosion.transform.position = this.transform.position;
        deathExplosion.SetColor(color);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpsRemaining = numJumps;
        }
    }

}
