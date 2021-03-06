﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonString : MonoBehaviour {

    [SerializeField]
    private GrabSlot[] grabSlots;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Attach(GameObject _gObj) {
        
        PlayerController playerController = _gObj.GetComponent<PlayerController>();

        // Don't grab if player is already grabbing a string
        if (playerController.IsGrabbingBalloonString()) return;

        for (int i = 0; i < grabSlots.Length; i++) {

            GrabSlot grabSlot = grabSlots[i];
            if (grabSlot.playerInUse == null) {
                playerController.Attach(this, grabSlot);
                grabSlot.playerInUse = playerController;
                break;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Player") {
            Attach(collision.gameObject);
        }

    }

    [Serializable]
    public class GrabSlot {
        public Transform transform;
        public PlayerController playerInUse = null;
    }

}
