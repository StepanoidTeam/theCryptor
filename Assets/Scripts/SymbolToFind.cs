using UnityEngine;
using System.Collections;

public class SymbolToFind : MonoBehaviour {

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
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        textBox = GetComponentInChildren<UnityEngine.UI.Text>();

    }

    public void Open() {
        animator.SetTrigger("Open");
    }

    public void Activate()
    {
        animator.SetTrigger("Activate");
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }

}
