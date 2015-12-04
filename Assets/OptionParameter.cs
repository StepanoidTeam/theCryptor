using UnityEngine;
using System.Collections;

public class OptionParameter : MonoBehaviour
{
    public string Text;
    public string ParameterName;

    UnityEngine.UI.Text paramNameTextbox;
    UnityEngine.UI.Text paramValueTextbox;
    UnityEngine.UI.Slider paramValueSlider;

    

    void Awake() {
       
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
