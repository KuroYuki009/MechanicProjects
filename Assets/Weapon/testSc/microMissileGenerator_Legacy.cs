using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microMissileGenerator_Legacy : MonoBehaviour
{
    [SerializeField] GameObject[] GeneratPoint;
    [SerializeField] GameObject missileObj;

    bool shotSW;
    float timeScale;
    int shotCount;


    void Start()
    {

    }

    void Update()
    {

        //�v���O�����N��
        if (Input.GetButtonDown("Fire1"))
        {
            shotSW = true;
        }

        //shotSW��true�̊ԁA���Ԋu�ŃA�^�b�`�����~�T�C���𔭎˂���BshotCount��3�ȏ�ɂȂ�Ɛ��l�����������AshotSW��false�ɂ�������������B�@
        if (shotSW == true)
        {
            timeScale += 1 * Time.deltaTime;

            if (timeScale >= 0.2f && shotCount <= 3)
            {
                Instantiate(missileObj, GeneratPoint[shotCount].transform.position, Quaternion.Euler(-90, -90, 90));
                shotCount += 1;
                timeScale = 0;
            }
            else if (shotCount >= 3)
            {
                timeScale = 0;
                shotCount = 0;
                shotSW = false;
            }
        }
    }
}
