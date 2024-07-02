using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_ArtemisGenerator : MonoBehaviour
{
    [SerializeField]GameObject shootObject;

    [SerializeField] GameObject barrelPoint_L;
    [SerializeField] GameObject barrelPoint_R;

    bool inputSW;
    void Update()
    {
        if(inputSW == true)
        {
            Instantiate(shootObject, barrelPoint_L.transform.position, Quaternion.Euler(-45,-90, 0));
            Instantiate(shootObject, barrelPoint_R.transform.position, Quaternion.Euler(-45, 90, 0));

            inputSW = false;
        }
        
    }

    public void FireInput()
    {
        inputSW = true;
    }
}
