using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//gui使う予定。

[CreateAssetMenu(fileName = "alphaCustomDate")]
public class alphaCustomEdit : ScriptableObject
{
    public List<CustomDate> CcstomDate;

    [System.Serializable]
    public class CustomDate
    {
        ////ファイル情報を参照する際にはint型で参照する必要がある。(将来的にはstring型で参照出来るようにする。)
        public string Name;//名前。
        public string IconString;//参照するUIスプライトのリソースリファレンスを記載。
        [Multiline(4)]public string Commentary;//説明文。ゲーム内で視覚的に情報を説明する際に使う。
        public string ReferenceString;//参照するプレハブのリソースリファレンを記載。

        ////プレハブ自体にダメージ数値などを持たせる為、こちらから要素を持たせる必要が無くなった。
        //public float PointValue;//保持している数値。攻撃系に使う場合には数値にマイナスを付ける必要がある。

    }
}
