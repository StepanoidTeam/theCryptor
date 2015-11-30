using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    #region Events
    public delegate void FadeEventHandler(GameObject sender);

    public event FadeEventHandler OnFade;
    #endregion
    
    void SymbolAnimationEnd()
    {
        if (OnFade != null)
        {
            OnFade(gameObject);
        }
    }

}
