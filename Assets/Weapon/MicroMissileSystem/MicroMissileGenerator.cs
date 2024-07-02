using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissileGenerator : MonoBehaviour
{
    //格納用
    [SerializeField] public List<Transform> lockOnObjs;//ロックオンしたオブジェクトを取得。
    [SerializeField] public List<Transform> targetObjs;//ロックオンしたオブジェクトを取得。

    [SerializeField]private bool shotSW;//
    [SerializeField]float timeScale;

    int lockOnCount;
    int targetCount;
    int shootCounter = 0;
    int barrelCounter = 0;

    //アタッチ用
    [SerializeField] GameObject microMissileObj;

    //変数用
    [SerializeField] int stockmissile;//現在装填数。
    [SerializeField] int maxStockMissile;//最大装填数。
    //[SerializeField] int backStockMissile = 30;//有限在庫弾数30発。
    string rootSwitch;//switchに使います。

    [SerializeField]
    public List<Transform> shootBarrels = new List<Transform>();//

    void Start()
    {
        maxStockMissile = 6;//6発格納
        stockmissile = maxStockMissile;
        
    }

    void Update()
    {
        lockOnCount = lockOnObjs.Count;//ロックオンしている数を取得する。

        //[テスト機能]起動
        if (Input.GetButtonDown("Fire1") && shotSW == false)
        {
            if(lockOnCount != 0 && stockmissile != 0)
            {
                targetObjs = new List<Transform>(lockOnObjs);
                targetCount = targetObjs.Count;
                rootSwitch = "SetUp";
                shotSW = true;
            }
            
        }

        //[テスト機能]クイックリロード
        if (Input.GetKeyDown(KeyCode.R) && shotSW==false)
        {
            stockmissile = maxStockMissile;
        }

        if (lockOnCount == 0 && shotSW == true)
        {
            shotSW = false;
        }

        if (shotSW == true)
        {
            switch(rootSwitch)
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
                    break;
            }
        }
    }

    void Shoot()
    {
        timeScale = 0;

        if (stockmissile >= 0)
        {

            if (targetObjs[shootCounter] == null) shotSW = false;// ターゲットが格納されていない場合は、射撃を中断させる。

            else if(targetObjs[shootCounter] != null)
            {
                GameObject shootMicroMissile = null;
                shootMicroMissile =
                    Instantiate(microMissileObj, shootBarrels[barrelCounter].position, Quaternion.Euler(-90, -90, 90));
                MicroMissile_Weapon mmw = shootMicroMissile.GetComponent<MicroMissile_Weapon>();

                mmw.targetTF = targetObjs[shootCounter];// インスタンス化した弾に標的となるオブジェクトの情報を渡す。

                stockmissile -= 1;
                shootCounter += 1;
                barrelCounter += 1;

            }
        }

        if (stockmissile <= 0)
            shotSW = false;
        else
            rootSwitch = "CoolTime";
    }

    void CoolTime()
    {
        if (timeScale <= 0.02f)
        {

            timeScale += 1.0f * Time.deltaTime;
        }
        else if (timeScale >= 0.02f)
        {
            if (shootCounter >= targetCount)
            {
                shootCounter = 0;
            }
            rootSwitch = "Shoot";
        }
    }

    void SetUp()
    {
        barrelCounter = 0;
        shootCounter = 0;
        rootSwitch = "Shoot";
    }
}
