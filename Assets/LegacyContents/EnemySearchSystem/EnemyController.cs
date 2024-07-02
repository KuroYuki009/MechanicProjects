using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] SearchColliderConvert searchObject;
    bool discoverSW;

    //switch‚ğ“®‚©‚·ˆ×‚Ìstring;
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
                Debug.Log("test‚Å‚Ó‚§‚é‚Æ");      //–¢‘I‘ğB
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
