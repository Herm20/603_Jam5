﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : Item {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Use(Vector2 _direction)
    {
        player.GetJet();
    }
}
