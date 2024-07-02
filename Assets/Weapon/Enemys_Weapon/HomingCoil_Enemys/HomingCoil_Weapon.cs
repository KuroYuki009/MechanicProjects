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
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//�G���������猩�Ăǂ̕��p�ɂ��邩�����G����B


                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.5f);//��]�p�x��^����B�f�t�H���g�l��0.5f�B

            timeScale += 1 * Time.deltaTime;//���Ԃ��o�߂�����B
        }
        Destroy(this.gameObject,5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * 50.0f;//�e�̑��x�B
    }
    private void OnCollisionEnter(Collision collision)//�Ԃ������ۂ̏����B
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Enemy_ATK")
        {
            if (collision.gameObject.tag == "Player") Debug.Log("DamegeHIT!!");
            Destroy(this.gameObject);
        }
    }
}
