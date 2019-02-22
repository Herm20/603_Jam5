using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputController : MonoBehaviour {

    public PlayerController playerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0)) {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(playerController.transform.position);
            Vector3 jumpDirection = (mousePosition - playerScreenPosition).normalized;

            playerController.Jump(jumpDirection, 1);

        }

	}

}
