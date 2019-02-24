using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : Item {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Use(Vector2 _direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(_direction.x, _direction.y, 0.0f), Quaternion.identity);
        bullet.GetComponent<BulletFreeze>().Fire(player.gameObject, player.GetComponent<Rigidbody2D>().velocity, _direction);
    }
}
