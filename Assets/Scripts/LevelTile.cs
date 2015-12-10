using UnityEngine;


public class LevelTile : MonoBehaviour
{

    public int LevelNumber;

    //public Renderer renderer;

    UnityEngine.UI.Button button;
    UnityEngine.UI.Text textbox;
    public bool Enabled
    {
        get
        {
            return button.interactable;
        }
        set
        {
            button.interactable = value;
        }
    }

    Material material;
    // Use this for initialization
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        textbox = GetComponentInChildren<UnityEngine.UI.Text>();


        Enabled = LevelNumber <= PlayerPrefs.GetFloat("game.lastlevel", 1);

        textbox.text = Enabled ? LevelNumber.ToString() : string.Empty;
    }


    public void StartLevel()
    {
        if (Enabled)
        {

            PlayerPrefs.SetFloat("game.currentlevel", LevelNumber);
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");//scene.LoadLevel
        }
    }


}
