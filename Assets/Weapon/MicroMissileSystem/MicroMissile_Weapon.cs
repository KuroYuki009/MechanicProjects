using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissile_Weapon : MonoBehaviour
{
    //�A�^�b�`�p�B�^�[�Q�b�g�ƂȂ�I�u�W�F�N�g��ݒ肷��B
    public Transform targetTF;

    //[�����I�@�\]�A�^�b�`�p�B�~�T�C���̃G�t�F�N�g
    public GameObject effectObject;

    //�ύX�\���l
    [SerializeField] float low_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��
    [SerializeField] float high_bendPower;//�ǂꂭ�炢�Ȃ���₷�����邩�̐��l�B��
    public float bulletSpeed;//

    //�i�[�p�B
    Rigidbody rb;
    Collider cd;
    float timeScale = 0.2f;//�|�b�v�A�b�v���̎��ԁB0.5f

    //�؂�ւ��p�B
    bool popUpSW;
    bool attackShootSW;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();

        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B

        bulletSpeed = 15.0f;//�e��
        low_bendPower = 0.05f;//��ǔ��B
        high_bendPower = 0.8f;//���ǔ��B

        attackShootSW = true;
        popUpSW = true;
    }

    void Update()
    {
        //���ˎ��B
        if(timeScale <= 0.0f)
        {

            popUpSW = false;
        }
        else if(popUpSW == true)
        {
            timeScale -= 1 * Time.deltaTime;
        }


        if (attackShootSW == true)//�Ώۂ̕����Ɍ����B
        {
            float distance = Vector3.Distance(gameObject.transform.position,targetTF.transform.position);//�G�Ƃ̋��������߂�B

            Quaternion lookRotation = 
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//�G���������猩�Ăǂ̕��p�ɂ��邩�����G����B

            
            if (distance <= 15f && popUpSW == false)//�^�[�Q�b�g�̋�������苗���ɋ���ꍇ�́A
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, high_bendPower);//������]�p�x���g�p����B
            else//
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, low_bendPower);//�ア��]�p�x���g�p����B
        }

    }

    void FixedUpdate()
    {

        //�ǔ��p
        if(attackShootSW == true)
        rb.velocity = transform.forward * bulletSpeed;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectObject, gameObject.transform.position, Quaternion.identity);//�G�t�F�N�g�����B
        Destroy(this.gameObject);
    }
}
