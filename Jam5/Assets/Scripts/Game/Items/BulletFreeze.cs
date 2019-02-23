using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFreeze : MonoBehaviour {
    public Vector2 direction;
    private float impact = 40.0f;

    private GameObject player;
    private float selfDelay = 0.25f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        selfDelay -= Time.deltaTime;
    }

    public void Fire(GameObject _player, Vector2 _velocity, Vector2 _direction)
    {
        player = _player;
        selfDelay = 0.25f;

        GetComponent<Rigidbody2D>().velocity = _velocity;
        GetComponent<Rigidbody2D>().AddForce(_direction * impact, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !(collision.gameObject == player && selfDelay > 0.0f))
        {
            collision.gameObject.GetComponent<PlayerController>().Freeze();
            Destroy(gameObject);
        }
    }
}
