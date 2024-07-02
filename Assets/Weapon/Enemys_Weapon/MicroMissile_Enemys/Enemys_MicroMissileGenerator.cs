using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_MicroMissileGenerator : MonoBehaviour
{
    //�O������2�ɒl
    bool inputSW;
    //�i�[�p
    [SerializeField] public Transform lockOnObj;//���b�N�I�������I�u�W�F�N�g���擾�B
    [SerializeField]private bool shotSW;//
    [SerializeField] float timeScale;


    int barrelCounter = 0;

    int shotBarrelUnit;//���ˏo����e���̐��B
    //�A�^�b�`�p
    [SerializeField] GameObject microMissileObj;

    //�ϐ��p
    [SerializeField] int stockmissile;//���ݑ��U���B
    [SerializeField] int maxStockMissile;//�ő呕�U���B
    string rootSwitch = default;//switch�Ɏg���܂��B

    [SerializeField]
    public List<Transform> shootBarrels = new List<Transform>();//

    void Start()
    {
        maxStockMissile = 12;//�i�[�e���B�f�t�H���g��12���B
        stockmissile = maxStockMissile;

        shotBarrelUnit = shootBarrels.Count;
    }

    void Update()
    {
        //[�e�X�g�@�\]�N��
      /*if (Input.GetKeyDown(KeyCode.Alpha9) && shotSW == false)
        {
            rootSwitch = "SetUp";
            shotSW = true;
        }*/
        //[�e�X�g�@�\]�N�C�b�N�����[�h
        if (Input.GetKeyDown(KeyCode.R))
        {
            stockmissile = maxStockMissile;
        }

        //�~�T�C������
        if (inputSW == true && shotSW == false)
        {
            rootSwitch = "SetUp";
            shotSW = true;
        }

        //����
        if (shotSW == true)
        {
            switch (rootSwitch)
            {
                case "Shoot":
                    //�����P
                    Shoot();
                    break;
                //�����Q
                case "CoolTime":
                    //�����Q
                    CoolTime();
                    break;
                case "SetUp":
                    //�����Q
                    SetUp();
                    //break��
                    break;
                default:
                    Default();
                    break;
            }
        }

    }

    public void FireInput()//�O�����甭�˂̐M����t���s���B
    {
        stockmissile = maxStockMissile;

        inputSW = true;
    }

    void Shoot()
    {
        timeScale = 0;

        if (stockmissile >= 0 && stockmissile != 0)
        {
            if (lockOnObj == null)//�����^�[�Q�b�g�����Ȃ��Ȃ����ꍇ�A
                shotSW = false;
            else
            {
                GameObject shootMicroMissile = null;
                shootMicroMissile =
                    Instantiate(microMissileObj, shootBarrels[barrelCounter].position, Quaternion.Euler(-90, -90, 90));
                MicroMissile_EnemysWeapon mmw = shootMicroMissile.GetComponent<MicroMissile_EnemysWeapon>();
                mmw.targetTF = lockOnObj;//�G�̍��W�𐶐������~�T�C���ɓ���Ēǔ�������B
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
        //�ҋ@�p
    }
}
