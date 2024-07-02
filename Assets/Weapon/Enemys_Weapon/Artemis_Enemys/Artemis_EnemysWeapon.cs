using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artemis_EnemysWeapon : MonoBehaviour
{
    //�A�^�b�`�p�B�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g��ݒ肷��B
    GameObject targetOBJ;
    public Transform targetTF;

    [SerializeField] GameObject pulseEffectObj;
    [SerializeField] GameObject shootEffectObj;

    [SerializeField] GameObject laserOBJ;//�A���e�~�X���[�U�[������B
    float shootTime;

    //�i�[�p
    Rigidbody rb;

    float timeScale;
    float shootingDelayTime;

    float progressTime;

    ArtemisLaser_EnemysWeapon al_ew;//���˂����I�u�W�F�N�g�̊i�[�B

    //�ύX�\���l�B�ǔ����\�B
    [SerializeField] float low_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��
    [SerializeField] float high_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��

    Vector3 instVT3;
    //���SW�B
    bool shotSW;
    bool ShootChargeSW;

    bool popUpSW;//���ˎ��̒��ˏオ��p��Bool�X�C�b�`�B
    bool attackShootSW;//�ǔ��U�����s���ׂ�Bool�X�C�b�`�B
    bool trackingSW = true;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        targetOBJ = GameObject.FindWithTag("Player");
        targetTF = targetOBJ.GetComponent<Transform>();
        al_ew = laserOBJ.GetComponent<ArtemisLaser_EnemysWeapon>();
        //nstantiate(effectObj, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B

        low_bendPower = 0.1f;//��ǔ��g�p���锭�ˊp�x�B�f�t�H���g�l��0.1f�B
        high_bendPower = 0.9f;//���ǔ��Ɏg�p���锭�ˊp�x�B�f�t�H���g�l��0.8f�B

        // randomFloat_low = Random.Range(0.0f, 0.5f);//�����_���Ȑ��l��I�o���A�ǔ����\�̐��l�ɉ�����B
        // randomFloat_high = Random.Range(0.0f, 0.5f);//�����_���Ȑ��l��I�o���A�ǔ����\�̐��l�ɉ�����B
        laserOBJ.SetActive(false);

        attackShootSW = true;
        popUpSW = true;
    }

    // Update is called once per frame
    void Update()
    {
        //���ˎ��B
        if (timeScale <= 0.0f && attackShootSW == false)
        {
            popUpSW = false;
            attackShootSW = true;

        }
        else if (popUpSW == true)
        {
            timeScale -= 1 * Time.deltaTime;
        }
         

        //�ǐՋ@�\
        if (attackShootSW == true && trackingSW == true)//�Ώۂ̕����Ɍ����B(���m�F�K�{)
        {
            
            float distance = Vector3.Distance(gameObject.transform.position, targetTF.transform.position);//�G�Ƃ̋��������߂�B

            Quaternion lookRotation =
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//�G���������猩�Ăǂ̕��p�ɂ��邩�����G����B

            progressTime += 1 * Time.deltaTime;

            if(progressTime >= 0.8)//���Ԃ�0.8�o�߂Ŕ��˓���B
            {
                Instantiate(pulseEffectObj, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B
                rb.velocity = Vector3.zero;
                ShootChargeSW = true;
            }

            if (distance <= 15f)//�^�[�Q�b�g�̋�������苗���ɋ���ꍇ�ɂ́A
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower);//������]�p�x���g�p����B
            else//�����łȂ���΁A
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower);//�ア��]�p�x���g�p����B

          if (distance <= 5f)//�^�[�Q�b�g����苗���ɋ���ꍇ�A�@�\���~�����˓���B
            {
                Instantiate(pulseEffectObj, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B
                rb.velocity = Vector3.zero;
                ShootChargeSW = true;
            }

        }
        if(ShootChargeSW == true)
        {
            //���Ԃ��o�߂����A��莞�Ԍ�Ƀ��[�U�[�𔭎˂���B
            shootingDelayTime += 1 * Time.deltaTime;
            trackingSW = false;
            attackShootSW = false;

            if(shootingDelayTime >= 0.5f)//���Ԃ�0.4���Ɣ����B
            {
                Instantiate(shootEffectObj, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B
                laserOBJ.SetActive(true);
                al_ew.shotSW = true;
            }
            else if (shootingDelayTime >= 0.2f)//���Ԃ�0.2�o�߂���Ɣ����B�^�[�Q�b�g�̕��֌���
            {
                Quaternion lookRotation =
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);
            }
        }

        if(al_ew.DestroySW == true)//���˂������[�U�[�I�u�W�F�N�g�����ˏI�������o������I�u�W�F�N�g���폜����B
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //�ǔ��e���p
        if (attackShootSW == true)
            rb.velocity = transform.forward * 45.0f;//�e�̑��x
    }
}
