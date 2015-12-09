using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayableSymbolProvider : MonoBehaviour, ISymbolProvider
{

    List<string> alphabet;

    public int SymbolsPerCell = 1;
    public float chance;

    // Use this for initialization
    void Awake()
    {
        alphabet = new List<string>() {
            "A", "B", "C", "D", "E",
            "F", "G", "H","I","J",
            "K","L", "M", "N", "O",
            "P","Q", "R", "S", "T",
            "U","V", "W", "X", "Y", "Z",

           // "1","2","3","4","5",
            //"6","7","8","9","0",
        };

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateSymbols()
    {


        for (var i = 0; i < 10; i++)
        {
            var symbolIndex = UnityEngine.Random.Range(0, alphabet.Count);

            //var symbol = alphabet[symbolIndex];
            alphabet.RemoveAt(symbolIndex);

            //AddSymbol(symbol);

        }
    }



    string ISymbolProvider.GetSymbol()
    {
        //if (Random.Range(0, 10) > 7 && checkpointSymbols != null)// % for checkpoint symbol to be generated
        //{
        //    currentSymbol = AddSymbol(checkpointSymbols.GetRandomSymbol());
        //}
        //else
        //{// other simple symbols

        //    var symbol = Random.Range(10, 99).ToString();
        //    currentSymbol = AddSymbol(symbol);
        //}

        string symbol=  string.Empty;
        for (var i = 0; i < SymbolsPerCell; i++) {
            var symbolIndex = UnityEngine.Random.Range(0, alphabet.Count);
            symbol += alphabet[symbolIndex];
        }

        return symbol;
    }
}
