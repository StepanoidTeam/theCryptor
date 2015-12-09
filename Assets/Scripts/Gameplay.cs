using UnityEngine;
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

    public List<string> CurrentSymbols;

    public int SymbolCount = 1;

    ISymbolProvider symbolProvider;

    int currentLevel = 1;

    // Use this for initialization
    void Start()
    {

        symbolProvider = GetComponent<ISymbolProvider>();

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

    #region gates
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

        firstGate.GetComponent<Animator>().SetTrigger("Open");
        Destroy(firstGate.gameObject, 1f);

        if (gates.Count <= 1)
        {
            WinGame();
        }

    }
    #endregion


    #region symbols
    void GenerateSymbols()
    {
        for (var i = 0; i < SymbolCount; i++)
        {
            AddSymbol(symbolProvider.GetSymbol());
        }
    }

    void AddSymbol(string symbol)
    {
        CurrentSymbols.Add(symbol);

        SymbolToFind stfGo = Instantiate(SymbolGo);
        stfGo.transform.SetParent(CheckpointSymbolContainer.transform);

        stfGo.transform.localScale = new Vector3(1, 1, 1);

        stfGo.Text = symbol;
    }

    internal string GetRandomSymbol()
    {
        if (CurrentSymbols.Count > 0)
        {
            return CurrentSymbols[Random.Range(0, CurrentSymbols.Count)];
        }
        return "Error";//todo: throw ex instead
    }

    public bool CheckSymbol(string symbol)
    {

        var symbolExists = CurrentSymbols.Contains(symbol);

        if (symbolExists)
        {
            RemoveSymbol(symbol);
            if (CurrentSymbols.Count == 0)
            {
                NextCheckpoint();
            }
        }

        return symbolExists;
    }

    public void RemoveAllSymbols()
    {
        CurrentSymbols.Clear();

        foreach (var checkpointSymbol in CheckpointSymbolContainer.transform.OfType<Transform>().ToList())
        {
            Destroy(checkpointSymbol.gameObject);
        }
    }

    public void RemoveSymbol(string symbol)
    {

        CurrentSymbols.Remove(symbol);

        foreach (var checkpointSymbol in CheckpointSymbolContainer.transform.OfType<Transform>().ToList())
        {
            var es = checkpointSymbol.GetComponent<SymbolToFind>();

            if (es.Text == symbol)
            {
                es.Close();
                
                //Destroy(es.gameObject);
                break;
            }
        }

    }

    #endregion


    #region gameflow

    public void NextCheckpoint()
    {
        SymbolCount++;
        RemoveGate();
        RemoveAllSymbols();
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

    public void WinGame()
    {
        GetComponent<ShipController>().Pause();
        WinGameContainer.SetActive(true);
    }

    public void NextLevel()
    {


        PlayerPrefs.SetInt("CurrentLevel", ++currentLevel);
        Application.LoadLevel("gameplay");
    }


    public void GameOver()
    {
        GetComponent<ShipController>().Pause();
        GameOverContainer.SetActive(true);

        SaveLastLevel();
    }


    private void SaveLastLevel()
    {
        if (currentLevel > PlayerPrefs.GetInt("game.lastlevel", 1))
        {
            PlayerPrefs.SetInt("game.lastlevel", currentLevel);
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
    #endregion


}
