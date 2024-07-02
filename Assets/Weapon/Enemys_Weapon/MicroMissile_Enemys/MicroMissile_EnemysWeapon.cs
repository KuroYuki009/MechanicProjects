using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissile_EnemysWeapon : MonoBehaviour
{
    //�A�^�b�`�p�B�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g��ݒ肷��B
    public Transform targetTF;

    //[�����I�@�\]�A�^�b�`�p�B�~�T�C���̃G�t�F�N�g
    [SerializeField] GameObject effectObject;

    //�ύX�\���l�B�ǔ����\�B
    [SerializeField] float low_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��
    [SerializeField] float high_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��

    float timeScale = 0.2f;//�|�b�v�A�b�v���̎��ԁB�f�t�H���g�l��0.2f�B�ύX�񐄏��B
    //�i�[�p�B
    Rigidbody rb;
    float randomFloat_low;
    float randomFloat_high;

    //�؂�ւ��p�B
    bool popUpSW;//���ˎ��̒��ˏオ��p��Bool�X�C�b�`�B
    bool attackShootSW;//�ǔ��U�����s���ׂ�Bool�X�C�b�`�B
    bool trackingSW = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B

        low_bendPower = 0.1f;//��ǔ��g�p���锭�ˊp�x�B�f�t�H���g�l��0.1f�B
        high_bendPower = 0.8f;//���ǔ��Ɏg�p���锭�ˊp�x�B�f�t�H���g�l��0.8f�B

        randomFloat_low = Random.Range(0.0f, 0.25f);//�����_���Ȑ��l��I�o���A�ǔ����\�̐��l�ɉ�����B
        randomFloat_high = Random.Range(0.0f, 0.25f);//�����_���Ȑ��l��I�o���A�ǔ����\�̐��l�ɉ�����B

        attackShootSW = true;
        popUpSW = true;
    }
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


            if (distance <= 12f)//�^�[�Q�b�g�̋�������苗���ɋ���ꍇ�ɂ́A
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower+randomFloat_high);//������]�p�x���g�p����B
            else//�����łȂ���΁A
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower+randomFloat_low);//�ア��]�p�x���g�p����B

            if (distance <= 7f) trackingSW = false;//�^�[�Q�b�g����苗���ɋ���ꍇ�A�ǔ��@�\����������B
        }
    }

    void FixedUpdate()
    {
        //�|�b�v�A�b�v�ł̎ˏo�p
        /*if(popUpSW == true)
        {
            //rb.velocity = new Vector3(0, 30, 0)* timeScale; //���^�B��ɔ�΂����Ƃ����ł��Ȃ��הp�~�B
            rb.velocity = transform.forward * 20 * timeScale; //�V�^�B�ǂ̕����ɂ���΂����Ƃ��ł���B
        }*/

        //�ǔ��e���p
        if (attackShootSW == true)
            rb.velocity = transform.forward * 28.0f;//�e�̑��x

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
