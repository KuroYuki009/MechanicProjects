using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnAimCursor : MonoBehaviour
{
    ////廃止済み。機能はスクリプト「LockOnCursorConvert」に統合されました。

    //変数用
    // bool LockedOnSW;//ロックオンされているかを判定する。

    void Start()
    {

    }


    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy_Cursor" && LockedOnSW == false)
        {
            LockedOnSW = true;
            collision.SendMessage("LockOn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy_Cursor" && LockedOnSW == true)
        {
            LockedOnSW = false;
            collision.SendMessage("LockOut");
        }
    }*/
}
