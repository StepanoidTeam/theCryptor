using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FallingChain : MonoBehaviour
{
    public static string[] symbols;

    public GameObject SymbolGo;

    public float StartDelayRandomMax = 1;
    public float DelayBetweenSymbols = 1;
    public int MaxSymbols = 13;

    ISymbolProvider symbolProvider;

    Gameplay checkpointSymbols;

    // Use this for initialization
    void Start()
    {
        //symbolProvider = GetComponent<ISymbolProvider>();
        symbolProvider = GetComponentsInParent<ISymbolProvider>()[0];

        checkpointSymbols = GetComponentInParent<Gameplay>();

        RemoveAllSymbols();

        if (symbolProvider != null)
        {
            StartCoroutine(AddSymbols());
        }
        else
        {
            Debug.LogWarning("symbol provider not set");
        }
    }


    IEnumerator AddSymbols()
    {
        GameObject currentSymbol = null;
        yield return new WaitForSeconds(Random.Range(0, StartDelayRandomMax));

        for (int i = 0; i < MaxSymbols; i++)
        {
            currentSymbol = AddFallingSymbol(symbolProvider.GetSymbol());
            yield return new WaitForSeconds(DelayBetweenSymbols);
        }

        currentSymbol.GetComponent<FallingSymbol>().OnFade += (sender) =>
        {
            RemoveAllSymbols();
            Start();
        };
    }


    private void RemoveAllSymbols()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    GameObject AddFallingSymbol(string symbol)
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
