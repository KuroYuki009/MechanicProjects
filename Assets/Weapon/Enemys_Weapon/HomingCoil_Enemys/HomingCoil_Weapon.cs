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
                Quaternion.LookRotation(targetTF.transform.position - transform.position, Vector3.forward);//“G‚ªŽ©•ª‚©‚çŒ©‚Ä‚Ç‚Ì•ûŠp‚É‚¢‚é‚©‚ðõ“G‚·‚éB


                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.5f);//‰ñ“]Šp“x‚ð—^‚¦‚éBƒfƒtƒHƒ‹ƒg’l‚Í0.5fB

            timeScale += 1 * Time.deltaTime;//ŽžŠÔ‚ðŒo‰ß‚³‚¹‚éB
        }
        Destroy(this.gameObject,5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * 50.0f;//’e‚Ì‘¬“xB
    }
    private void OnCollisionEnter(Collision collision)//‚Ô‚Â‚©‚Á‚½Û‚Ìˆ—B
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Enemy_ATK")
        {
            if (collision.gameObject.tag == "Player") Debug.Log("DamegeHIT!!");
            Destroy(this.gameObject);
        }
    }
}
