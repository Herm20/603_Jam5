using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {

        GameObject gObj = collision.gameObject;
        if (gObj.tag == "Player") {
            PlayerController pController = gObj.GetComponent<PlayerController>();
            pController.Die();
        }

    }

}
