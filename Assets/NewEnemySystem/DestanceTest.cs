using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestanceTest : MonoBehaviour
{
    public Transform target;
    public float targetDistance;

    int b;
    void Start()
    {
        
    }

    
    void Update()
    {
        //��������e�X�g
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float ds = Vector3.Distance(transform.position, target.position);
            Debug.Log(ds);
            if (ds >= 50)
            {
                Debug.Log("�ǐ�");
            }
            else if (ds >= 25)
            {
                Debug.Log("�ڋ�");
            }
            /*float ds = (transform.position - target.position).sqrMagnitude;
            Debug.Log(ds);*/
        }

        //���[�v���̃e�X�g
        while (b < 10)
        {
            ++b;
            Debug.Log("while�ȃ��[�v�I�\��I");
            if (b > 10) break;
        }
        if (Input.GetKeyDown(KeyCode.Space)) b = 0;
    }
}
