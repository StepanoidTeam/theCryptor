using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeTextWithSlider : MonoBehaviour {

    public Text textLabel;
    public Slider optionsSlider;

    void Awake() {
        SetTextLabel();
    }

    public void SetTextLabel() {
        textLabel.text = optionsSlider.value.ToString();
    }
}
