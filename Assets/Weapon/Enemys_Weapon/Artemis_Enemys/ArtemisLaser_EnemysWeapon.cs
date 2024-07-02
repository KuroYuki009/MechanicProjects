using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtemisLaser_EnemysWeapon : MonoBehaviour
{
    public bool shotSW;

    float shootTime;
    float LaserScale;//���[�U�[�̃T�C�Y�B�f�t�H���g�l��0.2f�B

    public bool DestroySW;
    private void Start()
    {
        LaserScale = 0.12f;
    }
    void Update()
    {
        if(shotSW == true)
        {
            if (shootTime <= 0.1f)
            {

                gameObject.transform.localScale += new Vector3(LaserScale, 0, LaserScale);

                shootTime += 1 * Time.deltaTime;
            }
            else if (shootTime <= 0.2f)
            {
                gameObject.transform.localScale -= new Vector3(LaserScale, 0, LaserScale);

                shootTime += 1 * Time.deltaTime;
            }
            else
            {
                DestroySW = true;
            }
        }
    }
}
