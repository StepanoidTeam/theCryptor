﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Gameplay : MonoBehaviour
{


    public GameObject CheckpointSymbolContainer;
    public SymbolToFind SymbolGo;

    public GameObject CheckpointGateContainer;
    public GameObject GateGo;

    public GameObject GameOverContainer;
    public GameObject GamePauseContainer;
    public GameObject WinGameContainer;

    public Text LevelText;

    public List<string> Symbols;

    public int SymbolCount = 1;



    int CheckpointCount = 3;

    int currentLevel = 1;

    // Use this for initialization
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        StartLevel(currentLevel);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
            
        }

    }

    void ShowCurrentLevel()
    {
        LevelText.text = string.Format("lvl {0}", currentLevel);
    }

    private void GenerateGates(int gateCount)
    {
        RemoveAllGates();

        for (var i = 0; i < gateCount; i++)
        {

            var go = Instantiate(GateGo);
            go.transform.SetParent(CheckpointGateContainer.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }


    }

    private void RemoveAllGates()
    {
        foreach (var gate in CheckpointGateContainer.transform.OfType<Transform>().ToList())
        {
            Destroy(gate.gameObject);
        }
    }

    private void RemoveGate()
    {
        var gates = CheckpointGateContainer.transform.OfType<Transform>().ToList();
        var firstGate = gates.FirstOrDefault();

        firstGate.GetComponent<Animator>().SetBool("IsOpen", true);
        Destroy(firstGate.gameObject, 1f);

        if (gates.Count <= 1)
        {
            WinGame();
        }

    }



    void GenerateSymbols()
    {
        var alphabet = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "X", "Y", "Z" };
        for (var i = 0; i < SymbolCount; i++)
        {
            var symbolIndex = Random.Range(0, alphabet.Count);

            var symbol = alphabet[symbolIndex];
            alphabet.RemoveAt(symbolIndex);

            AddSymbol(symbol);

        }
        // yield return null;
    }

    SymbolToFind AddSymbol(string symbol)
    {
        Symbols.Add(symbol);

        SymbolToFind stfGo = Instantiate(SymbolGo);
        //var txt = stfGo.GetComponentInChildren<Text>();
        stfGo.transform.SetParent(CheckpointSymbolContainer.transform);
        //txt.rectTransform.SetParent(CheckpointSymbolContainer.transform);
        
        //txt.text = symbol;
        stfGo.transform.localScale = new Vector3(1, 1, 1);
        
        stfGo.Text = symbol;
        //txt.rectTransform.localScale = new Vector3(1, 1, 1);
        return stfGo;
    }

    internal string GetRandomSymbol()
    {
        if (Symbols.Count > 0)
        {
            return Symbols[Random.Range(0, Symbols.Count - 1)];
        }
        return "Error";//todo: throw ex instead
    }

    public bool CheckSymbol(string symbol)
    {

        var symbolExists = Symbols.Contains(symbol);

        if (symbolExists)
        {
            RemoveSymbol(symbol);
            if (Symbols.Count == 0)
            {
                NextCheckpoint();
            }
        }

        return symbolExists;
    }

    public void RemoveAllSymbols()
    {
        Symbols.Clear();

        foreach (var checkpointSymbol in CheckpointSymbolContainer.transform.OfType<Transform>().ToList())
        {
            Destroy(checkpointSymbol.gameObject);
        }
    }

    public void RemoveSymbol(string symbol)
    {

        Symbols.Remove(symbol);

        foreach (var checkpointSymbol in CheckpointSymbolContainer.transform.OfType<Transform>().ToList())
        {
            var es = checkpointSymbol.GetComponent<SymbolToFind>();

            if (es.Text == symbol)
            {
                Destroy(es.gameObject);
                break;
            }
        }

    }


    public void NextCheckpoint()
    {
        SymbolCount++;
        RemoveGate();
        GenerateSymbols();


    }

    public void StartLevel(int levelNumber)
    {
        GetComponent<ShipController>().RestartShip(30 * levelNumber);

        currentLevel = levelNumber;

        SymbolCount = levelNumber;

        ShowCurrentLevel();

        GenerateGates(levelNumber);
        RemoveAllSymbols();
        GenerateSymbols();


        ContinueGame();
    }

    public void WinGame() {
        GetComponent<ShipController>().Pause();
        WinGameContainer.SetActive(true);
    }

    public void NextLevel() {


        PlayerPrefs.SetInt("CurrentLevel", ++currentLevel);
        Application.LoadLevel("gameplay");
    }


    public void GameOver()
    {
        GetComponent<ShipController>().Pause();
        GameOverContainer.SetActive(true);

        SaveLastLevel();
    }


    private void SaveLastLevel() {
        if (currentLevel > PlayerPrefs.GetInt("LastLevel", 1))
        {
            PlayerPrefs.SetInt("LastLevel", currentLevel);
        }
    }


    public void PauseGame()
    {
        GetComponent<ShipController>().Pause();
        GamePauseContainer.SetActive(true);

        SaveLastLevel();
    }

    public void ContinueGame()
    {
        GetComponent<ShipController>().Resume();
        GamePauseContainer.SetActive(false);
        WinGameContainer.SetActive(false);

    }

    public void RestartLevel()
    {
        Application.LoadLevel("gameplay");
    }


    public void BackToMenu()
    {
        Application.LoadLevel("menu");
    }

}
