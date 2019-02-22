using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject cam;
    private Vector3 position;
    [SerializeField] private float speed;

	// Use this for initialization
	void Start () {
        cam = Camera.main.gameObject;
        position = cam.transform.position;
        speed = 2.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        position.y += speed * Time.deltaTime;

        cam.transform.position = position;
	}
}
