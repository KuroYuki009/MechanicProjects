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
        //距離測定テスト
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float ds = Vector3.Distance(transform.position, target.position);
            Debug.Log(ds);
            if (ds >= 50)
            {
                Debug.Log("追跡");
            }
            else if (ds >= 25)
            {
                Debug.Log("接近");
            }
            /*float ds = (transform.position - target.position).sqrMagnitude;
            Debug.Log(ds);*/
        }

        //ループ文のテスト
        while (b < 10)
        {
            ++b;
            Debug.Log("whileなループ！十回！");
            if (b > 10) break;
        }
        if (Input.GetKeyDown(KeyCode.Space)) b = 0;
    }
}
