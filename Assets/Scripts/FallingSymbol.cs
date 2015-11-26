using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FallingSymbol : MonoBehaviour
{

    public GameObject DestroyEffect;

    public bool IsClickable = true;

    public string SymbolText
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



    Gameplay checkpointSymbols;
    UnityEngine.UI.Text textBox;

    void Start()
    {
        checkpointSymbols = GetComponentInParent<Gameplay>();
        textBox = GetComponent<UnityEngine.UI.Text>();
    }

    public void OnPointerClickWithBaseData(BaseEventData data)
    {
        if (!IsClickable) return;

        PointerEventData ped = (PointerEventData)data;


        if (checkpointSymbols.CheckSymbol(SymbolText))
        {
            SymbolText = " ";
            DisplayDestroyEffectOn(this.gameObject);

        }
        else
        {
            SymbolText = "#";
        }

    }


    void DisplayDestroyEffectOn(GameObject go)
    {
        var effect = Instantiate(DestroyEffect);
        effect.transform.position = go.transform.position + new Vector3(0, 0, -10);
        Destroy(go.gameObject, 1f);
        Destroy(effect.gameObject, 1f);
    }

}
