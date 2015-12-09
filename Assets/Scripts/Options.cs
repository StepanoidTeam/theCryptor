using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour
{


    public UnityEngine.UI.Text ProgressText;
    // Use this for initialization
    void Start()
    {
        ShowProgress();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            BackToMainMenu();

        }

    }

    public void BackToMainMenu()
    {

        Application.LoadLevel("menu");

    }

    public void ResetProgress()
    {

        PlayerPrefs.SetInt("game.lastlevel", 1);
        ShowProgress();
    }

    public void ShowProgress()
    {
        ProgressText.text = PlayerPrefs.GetInt("game.lastlevel", 1).ToString();
    }

    
}
