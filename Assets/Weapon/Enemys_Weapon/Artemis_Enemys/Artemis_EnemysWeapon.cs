using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artemis_EnemysWeapon : MonoBehaviour
{
    //アタッチ用。ターゲットとなるオブジェクトを設定する。
    GameObject targetOBJ;
    public Transform targetTF;

    [SerializeField] GameObject pulseEffectObj;
    [SerializeField] GameObject shootEffectObj;

    [SerializeField] GameObject laserOBJ;//アルテミスレーザーを入れる。
    float shootTime;

    //格納用
    Rigidbody rb;

    float timeScale;
    float shootingDelayTime;

    float progressTime;

    ArtemisLaser_EnemysWeapon al_ew;//発射したオブジェクトの格納。

    //変更可能数値。追尾性能。
    [SerializeField] float low_bendPower;//どれくらい曲がりやすくするかの数値。弱
    [SerializeField] float high_bendPower;//どれくらい曲がりやすくするかの数値。強

    Vector3 instVT3;
    //二極SW。
    bool shotSW;
    bool ShootChargeSW;

    bool popUpSW;//発射時の跳ね上がり用のBoolスイッチ。
    bool attackShootSW;//追尾攻撃を行う為のBoolスイッチ。
    bool trackingSW = true;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        targetOBJ = GameObject.FindWithTag("Player");
        targetTF = targetOBJ.GetComponent<Transform>();
        al_ew = laserOBJ.GetComponent<ArtemisLaser_EnemysWeapon>();
        //nstantiate(effectObj, gameObject.transform.position, Quaternion.identity);//エフェクト生成。

        low_bendPower = 0.1f;//弱追尾使用する発射角度。デフォルト値は0.1f。
        high_bendPower = 0.9f;//強追尾に使用する発射角度。デフォルト値は0.8f。

        // randomFloat_low = Random.Range(0.0f, 0.5f);//ランダムな数値を選出し、追尾性能の数値に加える。
        // randomFloat_high = Random.Range(0.0f, 0.5f);//ランダムな数値を選出し、追尾性能の数値に加える。
        laserOBJ.SetActive(false);

        attackShootSW = true;
        popUpSW = true;
    }

    // Update is called once per frame
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

            progressTime += 1 * Time.deltaTime;

            if(progressTime >= 0.8)//時間が0.8経過で発射動作。
            {
                Instantiate(pulseEffectObj, gameObject.transform.position, Quaternion.identity);//エフェクト生成。
                rb.velocity = Vector3.zero;
                ShootChargeSW = true;
            }

            if (distance <= 15f)//ターゲットの距離が一定距離に居る場合には、
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower);//強い回転角度を使用する。
            else//そうでなければ、
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower);//弱い回転角度を使用する。

          if (distance <= 5f)//ターゲットが一定距離に居る場合、機能を停止し発射動作。
            {
                Instantiate(pulseEffectObj, gameObject.transform.position, Quaternion.identity);//エフェクト生成。
                rb.velocity = Vector3.zero;
                ShootChargeSW = true;
            }

        }
        if(ShootChargeSW == true)
        {
            //時間を経過させ、一定時間後にレーザーを発射する。
            shootingDelayTime += 1 * Time.deltaTime;
            trackingSW = false;
            attackShootSW = false;

            if(shootingDelayTime >= 0.5f)//時間が0.4立つと発生。
            {
                Instantiate(shootEffectObj, gameObject.transform.position, Quaternion.identity);//エフェクト生成。
                laserOBJ.SetActive(true);
                al_ew.shotSW = true;
            }
            else if (shootingDelayTime >= 0.2f)//時間が0.2経過すると発生。ターゲットの方へ向く
            {
                Quaternion lookRotation =
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);
            }
        }

        if(al_ew.DestroySW == true)//発射したレーザーオブジェクトが発射終わりを検出したらオブジェクトを削除する。
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //追尾弾速用
        if (attackShootSW == true)
            rb.velocity = transform.forward * 45.0f;//弾の速度
    }
}
