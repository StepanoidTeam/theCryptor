using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionParameter : MonoBehaviour
{

    public string Text;
    public string ParameterName;

    public float sliderMinValue;
    public float sliderMaxValue;
    public float sliderValue;
    public bool switchWholeNumders;

    public Text paramNameTextbox;
    public Text paramValueTextbox;
    public Slider paramValueSlider;

    public float DefaultValue;


    void Awake()
    {
        SetNameTextbox();
        SetSlider();
        GetParameter();
    }

    void SetNameTextbox()
    {
        paramNameTextbox.text = ParameterName;
    }

    void SetSlider()
    {
        paramValueSlider.maxValue = sliderMaxValue;
        paramValueSlider.minValue = sliderMinValue;
        paramValueSlider.value = sliderValue;
        paramValueSlider.wholeNumbers = switchWholeNumders;
    }

    public void OnDestroy()
    {
        SetParameter();
    }

    public void SetParameter()
    {
        PlayerPrefs.SetFloat(ParameterName, paramValueSlider.value);
    }

    public void GetParameter()
    {
        paramValueSlider.value = PlayerPrefs.GetFloat(ParameterName, DefaultValue);
    }

    public void ResetParameter()
    {
        PlayerPrefs.SetFloat(ParameterName, DefaultValue);
        GetParameter();
    }
}
