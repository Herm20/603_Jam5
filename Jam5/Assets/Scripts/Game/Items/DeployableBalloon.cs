using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployableBalloon : Item {

    public GameObject balloonPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Use(Vector2 _direction)
    {
        Instantiate(balloonPrefab, transform.position, Quaternion.identity);
    }
}
