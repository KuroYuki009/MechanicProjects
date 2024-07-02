using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun_EnemysWeapon : MonoBehaviour
{
    public LayerMask t_LayerMask;
    void Start()
    {

    }


    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        Ray ray;
        RaycastHit hit;

        //レイを生成します。
        ray = new Ray(transform.position,transform.forward);
        Debug.DrawRay(transform.position,transform.forward *50f, Color.yellow);
        //飛ばしたRayの判定を取る。
        if (Physics.Raycast(ray,out hit,50f,t_LayerMask))
        {
            Debug.Log("Hit!!Hit!!Hit!!");
            

        }
    }
}
