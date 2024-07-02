using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissileGenerator : MonoBehaviour
{
    //�i�[�p
    [SerializeField] public List<Transform> lockOnObjs;//���b�N�I�������I�u�W�F�N�g���擾�B
    [SerializeField] public List<Transform> targetObjs;//���b�N�I�������I�u�W�F�N�g���擾�B

    [SerializeField]private bool shotSW;//
    [SerializeField]float timeScale;

    int lockOnCount;
    int targetCount;
    int shootCounter = 0;
    int barrelCounter = 0;

    //�A�^�b�`�p
    [SerializeField] GameObject microMissileObj;

    //�ϐ��p
    [SerializeField] int stockmissile;//���ݑ��U���B
    [SerializeField] int maxStockMissile;//�ő呕�U���B
    //[SerializeField] int backStockMissile = 30;//�L���݌ɒe��30���B
    string rootSwitch;//switch�Ɏg���܂��B

    [SerializeField]
    public List<Transform> shootBarrels = new List<Transform>();//

    void Start()
    {
        maxStockMissile = 6;//6���i�[
        stockmissile = maxStockMissile;
        
    }

    void Update()
    {
        lockOnCount = lockOnObjs.Count;//���b�N�I�����Ă��鐔���擾����B

        //[�e�X�g�@�\]�N��
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

        //[�e�X�g�@�\]�N�C�b�N�����[�h
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
                    break;
            }
        }
    }

    void Shoot()
    {
        timeScale = 0;

        if (stockmissile >= 0)
        {

            if (targetObjs[shootCounter] == null) shotSW = false;// �^�[�Q�b�g���i�[����Ă��Ȃ��ꍇ�́A�ˌ��𒆒f������B

            else if(targetObjs[shootCounter] != null)
            {
                GameObject shootMicroMissile = null;
                shootMicroMissile =
                    Instantiate(microMissileObj, shootBarrels[barrelCounter].position, Quaternion.Euler(-90, -90, 90));
                MicroMissile_Weapon mmw = shootMicroMissile.GetComponent<MicroMissile_Weapon>();

                mmw.targetTF = targetObjs[shootCounter];// �C���X�^���X�������e�ɕW�I�ƂȂ�I�u�W�F�N�g�̏���n���B

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
