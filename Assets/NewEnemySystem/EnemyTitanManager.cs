using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTitanManager : MonoBehaviour
{
    //
    [SerializeField] GameObject barrelObject;
    [SerializeField] GameObject shootObject;

    //�O�������̓��͂Ɏg�p����B
    [SerializeField] Enemys_MicroMissileGenerator e_Mmg;//�G��p�~�T�C���W�F�l���[�^�[�B
    [SerializeField] Enemys_ArtemisGenerator e_Amg;//�G��p�A���e�~�X�W�F�l���[�^�[�B
    Rigidbody rb;

    //�����ł̓�ɕϒl�p�B
    bool hoverMovingSW;
    bool boostMovingSW;
    bool tacticalMovingSW;
    bool backMovingSW;
    bool combatSW;

    //�����ł̕ϒl�p
    float cmb;
    float tcM;
    float shotCount;

    //�v���C���[���A�^�b�`����K�v������B
    public Transform playerTF;
    public Rigidbody playerRB;

    //SwitchRoot�p�B
    string switchRoot;
    string combatRoot;
    void Start()
    {
        //�v���C���[���^�O�ŒT���擾����B
        GameObject playerObj = GameObject.FindWithTag("Player");
        playerTF = playerObj.GetComponent<Transform>();
        playerRB = playerObj.GetComponent<Rigidbody>();

        switchRoot = "Searching";
        rb = GetComponent<Rigidbody>();
    }

    // �����ƍŏ��ɍ��G�A�v���C���[���߂��ɋ��Ȃ��ꍇ�A�o�������Ɉړ�����悤�ɂ���B
    void Update()
    {

        //�s���p
        switch (switchRoot)
        {
            case "Searching"://���G
                Searching();
                break;
            case "Combat"://�퓬
                Combat();
                break;
            default:
                //Debug.Log("�s���I��....");
                break;
        }

        //�퓬�p
        switch (combatRoot)
        {
            case "tacticalMove":// �ړ�
                tacticalMove();
                break;
            case "backMove":// �ړ�
                backMove();
                break;
            case "burstFire":// �ˌ��U��
                burstFire();
                break;
            case "missileBlast":// �}�C�N���~�T�C���ˏo
                MissileBlast();
                break;
            case "BootArtemis":// �A���e�~�X����
                BootArtemis();
                break;
            default:
                combatSW = false;
                //Debug.Log("�퓬�s���I��....");
                break;
        }
    }

    void Searching()//�v���C���[����苗���ɂ��邩�����G�B
    {
        float ds = Vector3.Distance(transform.position, playerTF.position);

        if (ds >= 70)// 65m����Ă���ƍ����ǐՂ��s���B
        {
            BoostChaser();
            //Debug.Log("�����ǐ�");
        }
        else if (ds >= 35)// 40m����Ă���ƕ��ʂ̑����ŒǐՂ���(�u�[�X�^�[�����Œǂ������Ă���B)
        {
            HoverChaser();
            //Debug.Log("�ʏ�ǐ�");
        }
        else
        {
            //Debug.Log("�퓬");
            boostMovingSW = false;
            hoverMovingSW = false;
            switchRoot = "Combat";
        }

    }

    void Combat()//�v���C���[�Ɛ퓬����B�����̍s���𖳍�ׂɍs���B
    {
        if (cmb <= 0.6f && combatSW == false)//�I�o�X�s�[�h
        {
            cmb += 1.0f * Time.deltaTime;
        }
        else if (combatSW == false)
        {
            int randomPoint = Random.Range(0, 12);

            if (randomPoint == 0)
            {
                combatRoot = "tacticalMove";
                //Debug.Log("��p�ړ�");
            }
            else if (randomPoint == 1)
            {
                combatRoot = "tacticalMove";
                //Debug.Log("��p�ړ�");
            }
            else if (randomPoint == 2)
            {
                combatRoot = "backMove";
                //Debug.Log("����U��");
            }
            else if (randomPoint == 3)
            {
                combatRoot = "burstFire";
                //Debug.Log("�ˌ��U��");
            }
            else if (randomPoint == 4)
            {
                combatRoot = "burstFire";
                //Debug.Log("�ˌ��U��");
            }
            else if (randomPoint == 5)
            {
                combatRoot = "burstFire";
                //Debug.Log("�ˌ��U��");
            }
            else if (randomPoint == 6)
            {
                combatRoot = "burstFire";
                //Debug.Log("�ˌ��U��");
            }
            else if (randomPoint == 7)
            {
                combatRoot = "burstFire";
                //Debug.Log("�ˌ��U��");
            }
            else if (randomPoint == 8)
            {
                combatRoot = "missileBlast";
                //Debug.Log("�~�T�C���ˏo");
            }
            else if (randomPoint == 9)
            {
                combatRoot = "missileBlast";
                //Debug.Log("�~�T�C���ˏo");
            }
            else if (randomPoint == 10)
            {
                combatRoot = "BootArtemis";
                //Debug.Log("�A���e�~�X����");
            }
            else if (randomPoint == 11)
            {
                combatRoot = "BootArtemis";
                //Debug.Log("�A���e�~�X����");
            }
            cmb = 0;

            //combatSW���I���ɂȂ�A���̓�����~�߂�B�ĉғ������邽�߂ɂ�combatSW��false�ɂ���K�v������B
            combatSW = true;
        }
    }

    void BoostChaser()//�ǐՃm�[�h�B�v���C���[��ǂ�������B
    {
        //�ܕb�o�߂���ƃv���C���[���W�Ƀ_�C���N�g�ړ����s���B
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        boostMovingSW = true;
        hoverMovingSW = false;
    }

    void HoverChaser()//�ǐՃm�[�h�B�v���C���[�ɋ߂Â��B
    {
        //�ܕb�o�߂���ƃv���C���[���W�Ƀ_�C���N�g�ړ����s���B
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        hoverMovingSW = true;
        boostMovingSW = false;
    }



    void tacticalMove()//�퓬���ɓ��I�ȍs�����s���B�O���ړ��B
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //FixedUpdate�ňړ����s���B
        tacticalMovingSW = true;

        if (tcM <= 0.5f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else
        {
            tacticalMovingSW = false;
            //�ϐ������Z�b�g���A�s�����Ē��I����B
            RefreshSW();
        }
    }
    void backMove()//�퓬���ɓ��I�ȍs�����s���B����ړ��B
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //FixedUpdate�ňړ����s���B
        backMovingSW = true;

        if (tcM <= 0.5f)
        {
            tcM += 1.0f * Time.deltaTime;
        }
        else
        {
            backMovingSW = false;
            //�ϐ������Z�b�g���A�s�����Ē��I����B
            RefreshSW();
        }
    }

    void burstFire()//�v���C���[�̕�����5�A�ˌ����s���B
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
            //�ϐ������Z�b�g���A�s�����Ē��I����B
            RefreshSW();
        }


    }

    void MissileBlast()//�v���C���[�Ɍ������Ēǔ����\���������}�C�N���~�T�C�����ˏo����B
    {
        e_Mmg.SendMessage("FireInput");
        RefreshSW();
    }

    void BootArtemis()//�v���C���[�Ɍ������Ēǔ����\���������}�C�N���~�T�C�����ˏo����B
    {
        e_Amg.SendMessage("FireInput");
        RefreshSW();
    }

    void meleeAttack()//�v���C���[�Ƃ̋�������苗���̏ꍇ�ɂ��ߐڍU�����s���B(�I�v�V����)
    {

    }

    void RefreshSW()// combat�̃X�e�[�g�I����Ɏ��s���邱�Ƃŕϐ��̐��l��߂��B
    {
        shotCount = 0;
        tcM = 0;
        combatSW = false;
        combatRoot = default;
        switchRoot = "Searching";
    }

    private void FixedUpdate()
    {
        //�ʏ�z�o�[�ł̈ړ����p�B�ړ����x��20f�𒴂���ƃI�t�ɂȂ�B
        if (hoverMovingSW == true && rb.velocity.magnitude < 20.0f)
            rb.AddForce(transform.forward * 40.0f, ForceMode.Force);

        //�u�[�X�g�ł̈ړ����p�B�ړ����x��30f�𒴂���ƃI�t�ɂȂ�B
        if (boostMovingSW == true && rb.velocity.magnitude < 40.0f)
            rb.AddForce(transform.forward * 60.0f, ForceMode.Force);

        //�퓬�ł̈ړ����p�B�ړ����x��20f�𒴂���ƃI�t�ɂȂ�B
        if (tacticalMovingSW == true && rb.velocity.magnitude < 8.5f)
            rb.AddForce(transform.forward * 60.0f, ForceMode.Force);
        //�퓬�ł̌���ړ����p�B�ړ����x��20f�𒴂���ƃI�t�ɂȂ�B
        if (backMovingSW == true && rb.velocity.magnitude < 8.5f)
            rb.AddForce(-transform.forward * 60.0f, ForceMode.Force);
    }
}
