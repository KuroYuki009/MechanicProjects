using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchColliderConvert : MonoBehaviour
{
    ////このスクリプトは別オブジェクトのTrigger取得用のスクリプトです。
    // > 別スクリプトでアタッチして「onTriggerSW」変数を取得してください。
    // > タグ指定により「Player」に反応します。
    public bool onTriggerSW;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        onTriggerSW = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        onTriggerSW = false;
    }
}
