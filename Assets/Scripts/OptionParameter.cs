using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OptionParameter : MonoBehaviour
{

    public string Text;
    public string Key;

    public float MinValue;
    public float MaxValue;
    public float DefaultValue;

    public bool SwitchWholeNumbers;

    public Text paramNameTextbox;
    public Slider paramValueSlider;


    void Awake()
    {
        SetTextboxName();
        SetSlider();
    }

    void SetTextboxName()
    {
        paramNameTextbox.text = Text;
    }

    void SetSlider()
    {
        paramValueSlider.maxValue = MaxValue;
        paramValueSlider.minValue = MinValue;
        paramValueSlider.wholeNumbers = SwitchWholeNumbers;
        LoadParameterValue();
    }

    public void OnDestroy()
    {
        SaveParameterValue();
    }

    public void SaveParameterValue()
    {
        PlayerPrefs.SetFloat(Key, paramValueSlider.value);
    }

    public void LoadParameterValue()
    {
        paramValueSlider.value = PlayerPrefs.GetFloat(Key, DefaultValue);
    }

    public void ResetParameterValue()
    {
        PlayerPrefs.SetFloat(Key, DefaultValue);
        LoadParameterValue();
    }
}
