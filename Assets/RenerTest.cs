using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenerTest : MonoBehaviour
{
    //格納用

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("映っていない");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    // 
    private void OnBecameVisible()
    {
        Debug.Log("映っている");
        gameObject.layer = LayerMask.NameToLayer("UI");
    }
}
