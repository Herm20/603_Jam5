using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 position = this.transform.position;
        position.y += speed * Time.fixedDeltaTime;
        this.transform.position = position;
    }
}
