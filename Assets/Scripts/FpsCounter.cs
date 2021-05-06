using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour {
    private Text text;
    private int averageFps;
    private float timePassed;
    private int framesDrawn;

    void Start() {
        text = GetComponent<Text>();
        timePassed = 0f;
        framesDrawn = 0;
    }

    void Update() {
        if (timePassed > 1f) {
            averageFps = (int) Math.Round(framesDrawn / timePassed);
            timePassed = 0f;
            framesDrawn = 0;
        }

        timePassed += Time.deltaTime;
        framesDrawn++;

        text.text = "FPS: " + Math.Round(1f / Time.deltaTime) + "\n"
            + "Average FPS: " + averageFps + "\n"
            + "Render time: " + Math.Round(Time.deltaTime * 1000f, 2) + "ms";
    }
}