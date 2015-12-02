using UnityEngine;
using System.Collections;

public class SymbolToFind : MonoBehaviour {

    public bool IsEnabled { get; set; }
    public bool IsCurrent { get; set; }

    public string Text
    {
        get
        {
            return textBox.text;
        }
        set
        {
            textBox.text = value;
        }
    }
    

    UnityEngine.UI.Text textBox;

    void Awake()
    {
        textBox = GetComponentInChildren<UnityEngine.UI.Text>();
    }
    
}
