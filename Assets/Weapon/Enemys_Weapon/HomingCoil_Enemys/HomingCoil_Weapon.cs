using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCoil_Weapon : MonoBehaviour
{
    Rigidbody rb;
    float timeScale;

    Transform targetTF;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindWithTag("Player");
        targetTF = playerObj.GetComponent<Transform>();

        //rb.AddForce(transform.forward * 70f, ForceMode.Impulse);
    }

    private void Update()
    {
        if (timeScale <= 0.2f)
        {
            Quaternion lookRotation =
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//敵が自分から見てどの方角にいるかを索敵する。


                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.5f);//回転角度を与える。デフォルト値は0.5f。

            timeScale += 1 * Time.deltaTime;//時間を経過させる。
        }
        Destroy(this.gameObject,5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * 50.0f;//弾の速度。
    }
    private void OnCollisionEnter(Collision collision)//ぶつかった際の処理。
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Enemy_ATK")
        {
            if (collision.gameObject.tag == "Player") Debug.Log("DamegeHIT!!");
            Destroy(this.gameObject);
        }
    }
}
