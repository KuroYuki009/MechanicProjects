using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTitanManager : MonoBehaviour
{
    //
    [SerializeField] GameObject barrelObject;
    [SerializeField] GameObject shootObject;

    //外部兵装の入力に使用する。
    [SerializeField] Enemys_MicroMissileGenerator e_Mmg;//敵専用ミサイルジェネレーター。
    [SerializeField] Enemys_ArtemisGenerator e_Amg;//敵専用アルテミスジェネレーター。
    Rigidbody rb;

    //内部での二極変値用。
    bool hoverMovingSW;
    bool boostMovingSW;
    bool tacticalMovingSW;
    bool backMovingSW;
    bool combatSW;

    //内部での変値用
    float cmb;
    float tcM;
    float shotCount;

    //プレイヤーをアタッチする必要がある。
    public Transform playerTF;
    public Rigidbody playerRB;

    //SwitchRoot用。
    string switchRoot;
    string combatRoot;
    void Start()
    {
        //プレイヤーをタグで探し取得する。
        GameObject playerObj = GameObject.FindWithTag("Player");
        playerTF = playerObj.GetComponent<Transform>();
        playerRB = playerObj.GetComponent<Rigidbody>();

        switchRoot = "Searching";
        rb = GetComponent<Rigidbody>();
    }

    // 沸くと最初に索敵、プレイヤーが近くに居ない場合、出口方向に移動するようにする。
    void Update()
    {

        //行動用
        switch (switchRoot)
        {
            case "Searching"://索敵
                Searching();
                break;
            case "Combat"://戦闘
                Combat();
                break;
            default:
                //Debug.Log("行動選択中....");
                break;
        }

        //戦闘用
        switch (combatRoot)
        {
            case "tacticalMove":// 移動
                tacticalMove();
                break;
            case "backMove":// 移動
                backMove();
                break;
            case "burstFire":// 射撃攻撃
                burstFire();
                break;
            case "missileBlast":// マイクロミサイル射出
                MissileBlast();
                break;
            case "BootArtemis":// アルテミス発射
                BootArtemis();
                break;
            default:
                combatSW = false;
                //Debug.Log("戦闘行動選択中....");
                break;
        }
    }

    void Searching()//プレイヤーが一定距離にいるかを索敵。
    {
        float ds = Vector3.Distance(transform.position, playerTF.position);

        if (ds >= 70)// 65m離れていると高速追跡を行う。
        {
            BoostChaser();
            //Debug.Log("高速追跡");
        }
        else if (ds >= 35)// 40m離れていると普通の速さで追跡する(ブースター無しで追いかけてくる。)
        {
            HoverChaser();
            //Debug.Log("通常追跡");
        }
        else
        {
            //Debug.Log("戦闘");
            boostMovingSW = false;
            hoverMovingSW = false;
            switchRoot = "Combat";
        }

    }

    void Combat()//プレイヤーと戦闘する。複数の行動を無作為に行う。
    {
        if (cmb <= 0.6f && combatSW == false)//選出スピード
        {
            cmb += 1.0f * Time.deltaTime;
        }
        else if (combatSW == false)
        {
            int randomPoint = Random.Range(0, 12);

            if (randomPoint == 0)
            {
                combatRoot = "tacticalMove";
                //Debug.Log("戦術移動");
            }
            else if (randomPoint == 1)
            {
                combatRoot = "tacticalMove";
                //Debug.Log("戦術移動");
            }
            else if (randomPoint == 2)
            {
                combatRoot = "backMove";
                //Debug.Log("後方攻撃");
            }
            else if (randomPoint == 3)
            {
                combatRoot = "burstFire";
                //Debug.Log("射撃攻撃");
            }
            else if (randomPoint == 4)
            {
                combatRoot = "burstFire";
                //Debug.Log("射撃攻撃");
            }
            else if (randomPoint == 5)
            {
                combatRoot = "burstFire";
                //Debug.Log("射撃攻撃");
            }
            else if (randomPoint == 6)
            {
                combatRoot = "burstFire";
                //Debug.Log("射撃攻撃");
            }
            else if (randomPoint == 7)
            {
                combatRoot = "burstFire";
                //Debug.Log("射撃攻撃");
            }
            else if (randomPoint == 8)
            {
                combatRoot = "missileBlast";
                //Debug.Log("ミサイル射出");
            }
            else if (randomPoint == 9)
            {
                combatRoot = "missileBlast";
                //Debug.Log("ミサイル射出");
            }
            else if (randomPoint == 10)
            {
                combatRoot = "BootArtemis";
                //Debug.Log("アルテミス発動");
            }
            else if (randomPoint == 11)
            {
                combatRoot = "BootArtemis";
                //Debug.Log("アルテミス発動");
            }
            cmb = 0;

            //combatSWがオンになり、この動作を止める。再稼働させるためにはcombatSWをfalseにする必要がある。
            combatSW = true;
        }
    }

    void BoostChaser()//追跡ノード。プレイヤーを追いかける。
    {
        //五秒経過するとプレイヤー座標にダイレクト移動を行う。
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        boostMovingSW = true;
        hoverMovingSW = false;
    }

    void HoverChaser()//追跡ノード。プレイヤーに近づく。
    {
        //五秒経過するとプレイヤー座標にダイレクト移動を行う。
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        hoverMovingSW = true;
        boostMovingSW = false;
    }



    void tacticalMove()//戦闘時に動的な行動を行う。前方移動。
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //FixedUpdateで移動を行う。
        tacticalMovingSW = true;

        if (tcM <= 0.5f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else
        {
            tacticalMovingSW = false;
            //変数をリセットし、行動を再抽選する。
            RefreshSW();
        }
    }
    void backMove()//戦闘時に動的な行動を行う。後方移動。
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //FixedUpdateで移動を行う。
        backMovingSW = true;

        if (tcM <= 0.5f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else
        {
            backMovingSW = false;
            //変数をリセットし、行動を再抽選する。
            RefreshSW();
        }
    }

    void burstFire()//プレイヤーの方向に5連射撃を行う。
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 shotPos = barrelObject.transform.position;


        if (tcM <= 0.15f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else if (shotCount <= 4.0f)
        {
            Instantiate(shootObject, shotPos, transform.rotation);
            shotCount += 1.0f;
            tcM = 0;
        }
        else
        {
            //変数をリセットし、行動を再抽選する。
            RefreshSW();
        }


    }

    void MissileBlast()//プレイヤーに向かって追尾性能を持ったマイクロミサイルを射出する。
    {
        e_Mmg.SendMessage("FireInput");
        RefreshSW();
    }

    void BootArtemis()//プレイヤーに向かって追尾性能を持ったマイクロミサイルを射出する。
    {
        e_Amg.SendMessage("FireInput");
        RefreshSW();
    }

    void meleeAttack()//プレイヤーとの距離が一定距離の場合により近接攻撃を行う。(オプション)
    {

    }

    void RefreshSW()// combatのステート終了後に実行することで変数の数値を戻す。
    {
        shotCount = 0;
        tcM = 0;
        combatSW = false;
        combatRoot = default;
        switchRoot = "Searching";
    }

    private void FixedUpdate()
    {
        //通常ホバーでの移動時用。移動速度が20fを超えるとオフになる。
        if (hoverMovingSW == true && rb.velocity.magnitude < 20.0f)
            rb.AddForce(transform.forward * 40.0f, ForceMode.Force);

        //ブーストでの移動時用。移動速度が30fを超えるとオフになる。
        if (boostMovingSW == true && rb.velocity.magnitude < 40.0f)
            rb.AddForce(transform.forward * 60.0f, ForceMode.Force);

        //戦闘での移動時用。移動速度が20fを超えるとオフになる。
        if (tacticalMovingSW == true && rb.velocity.magnitude < 8.5f)
            rb.AddForce(transform.forward * 60.0f, ForceMode.Force);
        //戦闘での後方移動時用。移動速度が20fを超えるとオフになる。
        if (backMovingSW == true && rb.velocity.magnitude < 8.5f)
            rb.AddForce(-transform.forward * 60.0f, ForceMode.Force);
    }
}
