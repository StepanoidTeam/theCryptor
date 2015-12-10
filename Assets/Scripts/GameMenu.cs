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
        
        var lastLevel = PlayerPrefs.GetFloat("game.lastlevel", 1);

        PlayerPrefs.SetFloat("game.currentlevel", lastLevel);

        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");
    }


    public void ShowLevelMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("levels");
    }

    public void ShowOptions() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("options");
    }
    
    
}
