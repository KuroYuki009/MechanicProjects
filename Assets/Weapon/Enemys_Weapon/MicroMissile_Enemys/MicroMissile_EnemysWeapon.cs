using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissile_EnemysWeapon : MonoBehaviour
{
    //アタッチ用。ターゲットとなるオブジェクトを設定する。
    public Transform targetTF;

    //[試験的機能]アタッチ用。ミサイルのエフェクト
    [SerializeField] GameObject effectObject;

    //変更可能数値。追尾性能。
    [SerializeField] float low_bendPower;//どれくらい曲がりやすくするかの数値。弱
    [SerializeField] float high_bendPower;//どれくらい曲がりやすくするかの数値。強

    float timeScale = 0.2f;//ポップアップ時の時間。デフォルト値は0.2f。変更非推奨。
    //格納用。
    Rigidbody rb;
    float randomFloat_low;
    float randomFloat_high;

    //切り替え用。
    bool popUpSW;//発射時の跳ね上がり用のBoolスイッチ。
    bool attackShootSW;//追尾攻撃を行う為のBoolスイッチ。
    bool trackingSW = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//エフェクト生成。

        low_bendPower = 0.1f;//弱追尾使用する発射角度。デフォルト値は0.1f。
        high_bendPower = 0.8f;//強追尾に使用する発射角度。デフォルト値は0.8f。

        randomFloat_low = Random.Range(0.0f, 0.25f);//ランダムな数値を選出し、追尾性能の数値に加える。
        randomFloat_high = Random.Range(0.0f, 0.25f);//ランダムな数値を選出し、追尾性能の数値に加える。

        attackShootSW = true;
        popUpSW = true;
    }
    void Update()
    {
        //直射式。
        if (timeScale <= 0.0f && attackShootSW == false)
        {
            popUpSW = false;
            attackShootSW = true;

        }
        else if (popUpSW == true)
        {
            timeScale -= 1 * Time.deltaTime;
        }


        //追跡機能
        if (attackShootSW == true && trackingSW == true)//対象の方向に向く。(軸確認必須)
        {
            float distance = Vector3.Distance(gameObject.transform.position, targetTF.transform.position);//敵との距離を求める。

            Quaternion lookRotation =
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//敵が自分から見てどの方角にいるかを索敵する。


            if (distance <= 12f)//ターゲットの距離が一定距離に居る場合には、
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower+randomFloat_high);//強い回転角度を使用する。
            else//そうでなければ、
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower+randomFloat_low);//弱い回転角度を使用する。

            if (distance <= 7f) trackingSW = false;//ターゲットが一定距離に居る場合、追尾機能を解除する。
        }
    }

    void FixedUpdate()
    {
        //ポップアップでの射出用
        /*if(popUpSW == true)
        {
            //rb.velocity = new Vector3(0, 30, 0)* timeScale; //旧型。上に飛ばすことしかできない為廃止。
            rb.velocity = transform.forward * 20 * timeScale; //新型。どの方向にも飛ばすことができる。
        }*/

        //追尾弾速用
        if (attackShootSW == true)
            rb.velocity = transform.forward * 28.0f;//弾の速度

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
