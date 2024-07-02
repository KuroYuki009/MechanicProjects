using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInst : MonoBehaviour
{
    public GameObject instObj;

    public Transform positionObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(instObj, positionObj);
    }
}
