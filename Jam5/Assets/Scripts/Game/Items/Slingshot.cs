using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Item {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Use(Vector2 _direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire(player.GetComponent<Rigidbody2D>().velocity, _direction);
    }
}
