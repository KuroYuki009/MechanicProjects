using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockOnEnemyManager : MonoBehaviour
{
    //敵のオブジェクトに接続して使用します。
    [SerializeField] GameObject instLockOnCursor;//インスタンス化するロックオン時カーソルを指定。
    [SerializeField] RectTransform canvasObject;//カーソルを子としてインスタンスする為のキャンバスを指定。

    //格納用
    private GameObject instCursorObject;//生成したカーソルのObject情報を格納する為の。
    LockOnCursorConvert cursorConvertComp;

    //変数用
    bool cameraBecameSW;
    void Start()
    {
        SetUp();
    }

    
    void Update()
    {
        
    }

    void SetUp()
    {
        //カーソルを生成し、このオブジェクト情報を渡す。
        instCursorObject = Instantiate(instLockOnCursor,canvasObject);
        cursorConvertComp = instCursorObject.GetComponent<LockOnCursorConvert>();
        cursorConvertComp.targetObject = this.gameObject;
        //locc = null;
    }

    private void OnBecameInvisible()
    {
        cursorConvertComp.objectBecameSW = false;
        cursorConvertComp.SendMessage("CursorRendering");
        Debug.Log("映っていない");
    }

    // 
    private void OnBecameVisible()
    {
        cursorConvertComp.objectBecameSW = true;
        cursorConvertComp.SendMessage("CursorRendering");
        Debug.Log("映っている");
    }
}
