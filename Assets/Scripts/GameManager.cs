using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Range(50, 5000)]
    public long durationMs = 1000;
    [SerializeField]
    private Slider slider;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void VibrationStarter()
    {
        Vibration.Vibrate(durationMs);
    }

    public void ChangeDurationSlider()
    {
        float newDurationMs = slider.value * 1000;
        durationMs = Convert.ToInt64(newDurationMs);
    }
}
