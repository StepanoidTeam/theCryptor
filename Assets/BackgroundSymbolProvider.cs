using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BackgroundSymbolProvider : MonoBehaviour, ISymbolProvider
{

    List<string> alphabet;

    public float chance;

    // Use this for initialization
    void Start()
    {
        alphabet = new List<string>() {
            "1","2","3","4","5",
            "6","7","8","9","0",
        };


    }

    // Update is called once per frame
    void Update()
    {

    }

    string ISymbolProvider.GetSymbol()
    {
        var symbolIndex = UnityEngine.Random.Range(0, alphabet.Count);
        var symbol = alphabet[symbolIndex];

        return symbol;
    }
}
