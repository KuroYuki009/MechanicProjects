using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_MachineGunTurret : MonoBehaviour
{
    //アタッチ用。
    [SerializeField]GameObject barrelOBJ;//砲塔にあたるオブジェクトを設定する必要がある。
    [SerializeField]GameObject targetOBJ;//目的となるターゲットを指定する必要がある。
    [SerializeField] GameObject shootingOBJ;//射撃する弾となるオブジェクトを選択。
    //格納用
    Vector3 barrelPos;//
    float tcM;
    public float shotCount;
    void Start()
    {
        barrelPos = barrelOBJ.transform.position;//取得したオブジェクトからVector3を取り出し格納する。
    }

    void Update()
    {
        Looking();
    }

    void Looking()
    {
        Quaternion barrelLookRotation = Quaternion.LookRotation(targetOBJ.transform.position - transform.position, Vector3.up);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, barrelLookRotation, 0.06f);
            

        if (tcM <= 0.2f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else if (shotCount <= 3.0f)
        {
            barrelPos = barrelOBJ.transform.position;
            Instantiate(shootingOBJ, barrelPos, transform.rotation);
            
            shotCount += 1.0f;
            tcM = 0;
        }
        else
        {
            //変数をリセットし、行動を再抽選する。
            shotCount = 0;
        }
    }
}
