using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    #region Events
    public delegate void FadeEventHandler(GameObject sender);

    public event FadeEventHandler OnFade;
    #endregion

    public float Delay = 2;
    public float Speed = 1;
    
    void SymbolAnimationEnd()
    {
        if (OnFade != null)
        {
            OnFade(gameObject);
        }
    }

}
