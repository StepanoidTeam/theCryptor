using UnityEngine;
using UnityEngine.UI;
using System;

public class ShipController : MonoBehaviour
{

    public Text timeoutText;


    public float CheckpointTimeout = 60;
    public Slider ShipSlider;


    float basicTimeout;

        
    // Use this for initialization
    void Start()
    {
        RestartShip(CheckpointTimeout);
    }


    bool IsPaused = false;

    public void Pause() {
        IsPaused = true;
    }

    public void Resume() {
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckpointTimeout > 0 && !IsPaused)
        {
            UpdateTimeout();
        }

        UpdateShipPosition();

        ShowTime();
    }

    void UpdateShipPosition() {
        var progress = 1 - CheckpointTimeout / basicTimeout;

        ShipSlider.value = progress;
    }

    void UpdateTimeout() {
        CheckpointTimeout -= Time.deltaTime;
    }


    void ShowTime()
    {
        var span = new TimeSpan(0, 0, (int)CheckpointTimeout);
        timeoutText.text = String.Format("{0:00}:{1:00}", span.Minutes, span.Seconds);
    }

    internal void RestartShip(float timeout)
    {
        ShipSlider.value = 0f;
        CheckpointTimeout = timeout;
        basicTimeout = CheckpointTimeout;
    }
}
