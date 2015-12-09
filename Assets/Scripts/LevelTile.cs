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


        Enabled = LevelNumber <= PlayerPrefs.GetInt("game.lastlevel", 1);

        textbox.text = Enabled ? LevelNumber.ToString() : string.Empty;
    }


    public void StartLevel()
    {
        if (Enabled)
        {

            PlayerPrefs.SetInt("CurrentLevel", LevelNumber);
            Application.LoadLevel("gameplay");
        }
    }


}
