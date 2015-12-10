using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
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

        SceneManager.LoadScene("menu");

    }
    
}
