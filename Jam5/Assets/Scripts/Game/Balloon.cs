using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float buoyancy;

    new private Rigidbody2D rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
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
