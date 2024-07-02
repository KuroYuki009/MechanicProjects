using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenerTest : MonoBehaviour
{
    //Ši”[—p

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("‰f‚Á‚Ä‚¢‚È‚¢");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    // 
    private void OnBecameVisible()
    {
        Debug.Log("‰f‚Á‚Ä‚¢‚é");
        gameObject.layer = LayerMask.NameToLayer("UI");
    }
}
