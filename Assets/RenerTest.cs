using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenerTest : MonoBehaviour
{
    //�i�[�p

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("�f���Ă��Ȃ�");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    // 
    private void OnBecameVisible()
    {
        Debug.Log("�f���Ă���");
        gameObject.layer = LayerMask.NameToLayer("UI");
    }
}
