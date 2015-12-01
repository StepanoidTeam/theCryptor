﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FallingChain : MonoBehaviour
{
    public static string[] symbols;

    public GameObject SymbolGo;

    public float StartDelayRandomMax = 1;
    public float DelayBetweenSymbols = 1;
    public int MaxSymbols = 13;


    Gameplay checkpointSymbols;

    // Use this for initialization
    void Start()
    {
        checkpointSymbols = GetComponentInParent<Gameplay>();


        StartCoroutine(AddSymbols());
    }


    IEnumerator AddSymbols()
    {
        GameObject currentSymbol = null;
        yield return new WaitForSeconds(Random.Range(0, StartDelayRandomMax));
        for (int i = 0; i < MaxSymbols; i++)
        {
            
            if (Random.Range(0,10) > 7 && checkpointSymbols!=null)// % for checkpoint symbol to be generated
            {
                currentSymbol = AddSymbol(checkpointSymbols.GetRandomSymbol());
            }
            else {// other simple symbols

                var symbol = Random.Range(10, 99).ToString();
                currentSymbol = AddSymbol(symbol);
            }


            yield return new WaitForSeconds(DelayBetweenSymbols);
        }
        currentSymbol.GetComponent<FallingSymbol>().OnFade += LastSymbol_OnFade;
    }

    private void LastSymbol_OnFade(GameObject sender)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Start();
    }

    GameObject AddSymbol(string symbol)
    {
        var go = Instantiate(SymbolGo);
        var txt = go.GetComponent<Text>();
        txt.rectTransform.SetParent(gameObject.transform);
        txt.text = symbol;
        txt.transform.localPosition = gameObject.transform.localPosition;
        go.transform.localScale = new Vector3(1, 1, 1);
        txt.rectTransform.localScale = new Vector3(1, 1, 1);

        return go;
    }
}