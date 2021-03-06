﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FallingSymbol : MonoBehaviour
{
    #region Events
    public delegate void FadeEventHandler(GameObject sender);

    public event FadeEventHandler OnFade;
    #endregion

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



    void SymbolAnimationEnd()
    {
        IsClickable = false;

        if (OnFade != null)
        {
            OnFade(gameObject);
        }
    }

    public void OnPointerClickWithBaseData(BaseEventData data)
    {
        if (!IsClickable) return;

        //PointerEventData ped = (PointerEventData)data;


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

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void DisplayDestroyEffectOn(GameObject go)
    {
        var effect = Instantiate(DestroyEffect);
        effect.transform.position = go.transform.position + new Vector3(0, 0, -10);
        //Destroy(go.gameObject, 1f);
        textBox.text = "";
        //Destroy();

        Destroy(effect.gameObject, 1f);
    }

}
