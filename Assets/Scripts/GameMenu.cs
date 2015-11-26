using UnityEngine;

public class GameMenu : MonoBehaviour
{
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();

        }

    }


    public void StartNewGame()
    {
        
        var lastLevel = PlayerPrefs.GetInt("LastLevel", 1);

        PlayerPrefs.SetInt("CurrentLevel", lastLevel);

        Application.LoadLevel("gameplay");
    }


    public void ShowLevelMenu()
    {
        Application.LoadLevel("levels");
    }

    public void ShowOptions() {
        Application.LoadLevel("options");
    }
    
    
}
