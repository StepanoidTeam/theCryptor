using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            BackToMainMenu();

        }

    }

    public void BackToMainMenu() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");

    }
}
