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

    void OnLastSymbolFade(object sender)
    {
        RemoveAllSymbols();
        Start();
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

        yield return new WaitForSeconds(2);

        OnLastSymbolFade(null);
        //currentSymbol.GetComponent<FallingSymbol>().OnFade -= OnLastSymbolFade;
        //currentSymbol.GetComponent<FallingSymbol>().OnFade += OnLastSymbolFade;
    }


    private void RemoveAllSymbols()
    {
        foreach (Transform child in transform)
        {

            //Destroy(child.gameObject);
            child.gameObject.SetActive(false);

        }
    }

    GameObject AddFallingSymbol(string symbol)
    {

        //var go = Instantiate(SymbolGo);
        var go = ObjectPooler.instance.GetPooledObject();


        //for text elem
        var txt = go.GetComponent<Text>();
        if (txt != null)
        {
            txt.rectTransform.SetParent(gameObject.transform);

            txt.text = symbol;
            txt.transform.localPosition = gameObject.transform.localPosition;
        }
        //for img stub
        var img = go.GetComponent<Image>();
        if (img != null) {
            img.rectTransform.SetParent(gameObject.transform);
            img.transform.localPosition = gameObject.transform.localPosition;
        }



        var fs = go.GetComponent<FallingSymbol>();
        fs.IsClickable = true;

        go.SetActive(true);


        return go;
    }
}
