using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionParameter : MonoBehaviour
{
    public string ParameterName;

    public string Text;

    public float sliderMinValue;
    public float sliderMaxValue;
    public float sliderValue;
    public bool switchWholeNumders;

    public Text paramNameTextbox;
    public Text paramValueTextbox;
    public Slider paramValueSlider;

    

    void Awake() {
        //paramNameTextbox = GetComponentInChildren<Text>();
        SetNameTextbox();
        SetSlider();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetNameTextbox() {
        paramNameTextbox.text = ParameterName;
    }

    void SetSlider() {
        paramValueSlider.maxValue = sliderMaxValue;
        paramValueSlider.minValue = sliderMinValue;
        paramValueSlider.value = sliderValue;
        paramValueSlider.wholeNumbers = switchWholeNumders;

    }

    public void SetParameter()
    {

        //PlayerPrefs.SetInt("LastLevel", 1);
        //ShowProgress();
    }

    public void GetParameter()
    {
        //ProgressText.text = PlayerPrefs.GetInt("LastLevel", 1).ToString();
    }
}
