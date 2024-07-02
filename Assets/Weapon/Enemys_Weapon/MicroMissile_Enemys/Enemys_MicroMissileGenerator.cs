using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_MicroMissileGenerator : MonoBehaviour
{
    //外部入力2極値
    bool inputSW;
    //格納用
    [SerializeField] public Transform lockOnObj;//ロックオンしたオブジェクトを取得。
    [SerializeField]private bool shotSW;//
    [SerializeField] float timeScale;


    int barrelCounter = 0;

    int shotBarrelUnit;//発射出来る銃口の数。
    //アタッチ用
    [SerializeField] GameObject microMissileObj;

    //変数用
    [SerializeField] int stockmissile;//現在装填数。
    [SerializeField] int maxStockMissile;//最大装填数。
    string rootSwitch = default;//switchに使います。

    [SerializeField]
    public List<Transform> shootBarrels = new List<Transform>();//

    void Start()
    {
        maxStockMissile = 12;//格納弾数。デフォルトは12発。
        stockmissile = maxStockMissile;

        shotBarrelUnit = shootBarrels.Count;
    }

    void Update()
    {
        //[テスト機能]起動
      /*if (Input.GetKeyDown(KeyCode.Alpha9) && shotSW == false)
        {
            rootSwitch = "SetUp";
            shotSW = true;
        }*/
        //[テスト機能]クイックリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            stockmissile = maxStockMissile;
        }

        //ミサイル発射
        if (inputSW == true && shotSW == false)
        {
            rootSwitch = "SetUp";
            shotSW = true;
        }

        //処理
        if (shotSW == true)
        {
            switch (rootSwitch)
            {
                case "Shoot":
                    //処理１
                    Shoot();
                    break;
                //条件２
                case "CoolTime":
                    //処理２
                    CoolTime();
                    break;
                case "SetUp":
                    //処理２
                    SetUp();
                    //break文
                    break;
                default:
                    Default();
                    break;
            }
        }

    }

    public void FireInput()//外部から発射の信号受付を行う。
    {
        stockmissile = maxStockMissile;

        inputSW = true;
    }

    void Shoot()
    {
        timeScale = 0;

        if (stockmissile >= 0 && stockmissile != 0)
        {
            if (lockOnObj == null)//もしターゲットが居なくなった場合、
                shotSW = false;
            else
            {
                GameObject shootMicroMissile = null;
                shootMicroMissile =
                    Instantiate(microMissileObj, shootBarrels[barrelCounter].position, Quaternion.Euler(-90, -90, 90));
                MicroMissile_EnemysWeapon mmw = shootMicroMissile.GetComponent<MicroMissile_EnemysWeapon>();
                mmw.targetTF = lockOnObj;//敵の座標を生成したミサイルに入れて追尾させる。
                                         //mmw.targetTF = null;

                stockmissile -= 1;
                barrelCounter += 1;

            }
        }

        if (stockmissile <= 0)
            shotSW = false;

        rootSwitch = "CoolTime";
    }

    void CoolTime()
    {
        if (timeScale <= 0.05f)
        {
            timeScale += 1.0f * Time.deltaTime;
        }
        else if (timeScale >= 0.05f)
        {
            if(barrelCounter >= shotBarrelUnit || barrelCounter == shotBarrelUnit)
            {
                barrelCounter = 0;
            }
            rootSwitch = "Shoot";
        }
    }

    void SetUp()
    {
        barrelCounter = 0;
        rootSwitch = "Shoot";

        inputSW = false;
    }

    void Default()
    {
        //待機用
    }
}
