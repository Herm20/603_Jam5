using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float buoyancy;
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

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        rigidbody.AddForce(Vector2.up * buoyancy * Time.fixedDeltaTime);
    }

}
