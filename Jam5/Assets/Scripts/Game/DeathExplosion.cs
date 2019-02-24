using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplosion : MonoBehaviour {

    private ParticleSystem pSystem;

    private void Awake() {
        pSystem = GetComponent<ParticleSystem>();
    }

    private void Update() {
        if (pSystem.isStopped) {
            Destroy(this.gameObject);
        }
    }

    public void SetColor(Color _color) {
        ParticleSystem.MainModule mainMod = GetComponent<ParticleSystem>().main;
        mainMod.startColor = _color;
    }

}
