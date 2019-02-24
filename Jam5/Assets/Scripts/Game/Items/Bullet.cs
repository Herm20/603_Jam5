using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float impact = 150.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Fire(Vector2 _velocity, Vector2 _direction)
    {
        GetComponent<Rigidbody2D>().velocity = _velocity;
        GetComponent<Rigidbody2D>().AddForce(_direction * impact, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Assuming this hits a balloon (layers?)
        Destroy(collision.gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    }
}
