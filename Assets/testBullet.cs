using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        rb.AddForce(transform.forward*70f, ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Enemy_ATK")
        {
            if(collision.gameObject.tag == "Player") Debug.Log("DamegeHIT!!");
            Destroy(this.gameObject);
        }
    }




}
