using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys_MachineGunTurret : MonoBehaviour
{
    //�A�^�b�`�p�B
    [SerializeField]GameObject barrelOBJ;//�C���ɂ�����I�u�W�F�N�g��ݒ肷��K�v������B
    [SerializeField]GameObject targetOBJ;//�ړI�ƂȂ�^�[�Q�b�g���w�肷��K�v������B
    [SerializeField] GameObject shootingOBJ;//�ˌ�����e�ƂȂ�I�u�W�F�N�g��I���B
    //�i�[�p
    Vector3 barrelPos;//
    float tcM;
    public float shotCount;
    void Start()
    {
        barrelPos = barrelOBJ.transform.position;//�擾�����I�u�W�F�N�g����Vector3�����o���i�[����B
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
            //�ϐ������Z�b�g���A�s�����Ē��I����B
            shotCount = 0;
        }
    }
}
