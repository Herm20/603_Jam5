using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour {

    [SerializeField]
    private CountdownStep[] countdownSteps;

    [SerializeField]
    private float stepLifetime;

    [SerializeField]
    private Image frontImage;
    [SerializeField]
    private Image backImage;

    [SerializeField]
    private AnimationCurve frontOffsetCurve;
    [SerializeField]
    private float frontOffsetScale;
    [SerializeField]
    private AnimationCurve backOffsetCurve;
    [SerializeField]
    private float backOffsetScale;

    public IEnumerator BeginCountdown() {

        for (int i = 0; i < countdownSteps.Length; i++) {

            CountdownStep stepData = countdownSteps[i];
            frontImage.sprite = stepData.frontSprite;
            backImage.sprite = stepData.backSprite;
            frontImage.color = stepData.frontSpriteColor;
            backImage.color = stepData.backSpriteColor;

            float lifetime = stepLifetime;
            while (lifetime > 0) {

                lifetime -= Time.deltaTime;
                float ratio = lifetime / stepLifetime;

                Vector3 frontPos = frontImage.transform.localPosition;
                frontPos.x = frontOffsetCurve.Evaluate(ratio) * frontOffsetScale;
                frontImage.transform.localPosition = frontPos;

                Vector3 backPos = backImage.transform.localPosition;
                backPos.x = backOffsetCurve.Evaluate(ratio) * backOffsetScale;
                backImage.transform.localPosition = backPos;

                yield return null;

            }

        }

        frontImage.sprite = null;
        frontImage.color = Color.clear;
        backImage.sprite = null;
        backImage.color = Color.clear;

    }

    [Serializable]
    private class CountdownStep {
        public Sprite frontSprite = null;
        public Color frontSpriteColor = Color.white;
        public Sprite backSprite = null;
        public Color backSpriteColor = Color.red;
    }

}
