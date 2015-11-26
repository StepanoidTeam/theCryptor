using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour
{

    Gameplay checkpointSymbols;

    // Use this for initialization
    void Start()
    {
        checkpointSymbols = GetComponentInParent<Gameplay>();
    }

   

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            col.GetComponent<Animator>().SetBool("IsCrashed", true);
            Debug.Log("Player died!");
            
            checkpointSymbols.GameOver();
        }

    }

}
