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





        //DynamicGI.SetEmissive(GetComponent<Renderer>(), new Color(0f, 0f, 0f, 0f) * 0f);

        //material = renderer.sharedMaterial;
        //material.SetFloat("_EMMISIVE", 1.0f);
        //can be set in the inspector



        Enabled = LevelNumber <= PlayerPrefs.GetInt("LastLevel", 1);

        textbox.text = Enabled ? LevelNumber.ToString() : string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        //material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;




        //material.SetColor("_EmissionColor", Color.red);
        //DynamicGI.UpdateMaterials(renderer);
        //DynamicGI.UpdateEnvironment();
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
