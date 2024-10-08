using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] SearchColliderConvert searchObject;
    bool discoverSW;

    //switchを動かす為のstring;
    string switchRoot;

    private void Start()
    {
        discoverSW = searchObject.onTriggerSW;
    }

    private void Update()
    {
        switch (switchRoot)
        {
            case "Searching":
                if (discoverSW == false) Searching();
                else if (discoverSW == true) switchRoot = "combat";
                break;
            case "Combat":
                if (discoverSW == true) Combat();
                break;
            default:
                Debug.Log("testでふぉると");      //未選択時。
                break;
        }
    }

    void Searching()
    {

    }

    void Combat()
    {

    }
}
