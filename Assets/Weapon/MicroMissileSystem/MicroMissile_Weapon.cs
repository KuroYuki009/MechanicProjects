using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissile_Weapon : MonoBehaviour
{
    //アタッチ用。ターゲットとなるオブジェクトを設定する。
    public Transform targetTF;

    //[試験的機能]アタッチ用。ミサイルのエフェクト
    public GameObject effectObject;

    //変更可能数値
    [SerializeField] float low_bendPower;//どれくらい曲がりやすくするかの数値。弱
    [SerializeField] float high_bendPower;//どれくらい曲がりやすくするかの数値。強
    public float bulletSpeed;//

    //格納用。
    Rigidbody rb;
    Collider cd;
    float timeScale = 0.2f;//ポップアップ時の時間。0.5f

    //切り替え用。
    bool popUpSW;
    bool attackShootSW;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();

        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//エフェクト生成。

        bulletSpeed = 15.0f;//弾速
        low_bendPower = 0.05f;//弱追尾。
        high_bendPower = 0.8f;//強追尾。

        attackShootSW = true;
        popUpSW = true;
    }

    void Update()
    {
        //直射式。
        if(timeScale <= 0.0f)
        {

            popUpSW = false;
        }
        else if(popUpSW == true)
        {
            timeScale -= 1 * Time.deltaTime;
        }


        if (attackShootSW == true)//対象の方向に向く。
        {
            float distance = Vector3.Distance(gameObject.transform.position,targetTF.transform.position);//敵との距離を求める。

            Quaternion lookRotation = 
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//敵が自分から見てどの方角にいるかを索敵する。

            
            if (distance <= 15f && popUpSW == false)//ターゲットの距離が一定距離に居る場合は、
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower);//強い回転角度を使用する。
            else//
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower);//弱い回転角度を使用する。
        }

    }

    void FixedUpdate()
    {

        //追尾用
        if(attackShootSW == true)
        rb.velocity = transform.forward * bulletSpeed;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//エフェクト生成。
        Destroy(this.gameObject);
    }
}
