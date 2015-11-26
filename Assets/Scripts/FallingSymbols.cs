using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FallingSymbols : MonoBehaviour
{
    public static string[] symbols;

    public GameObject SymbolGo;
    public GameObject Container;
    

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
                currentSymbol = AddSymbol(Random.Range(0, 10).ToString());
            }


            yield return new WaitForSeconds(DelayBetweenSymbols);
        }
        currentSymbol.GetComponent<Fadeout>().OnFade += LastSymbol_OnFade;
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
        txt.rectTransform.SetParent(Container.transform);
        txt.text = symbol;
        txt.transform.localPosition = Container.transform.localPosition;
        go.transform.localScale = new Vector3(1, 1, 1);
        txt.rectTransform.localScale = new Vector3(1, 1, 1);

        return go;
    }
}
