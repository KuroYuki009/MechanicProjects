using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroMissileController : MonoBehaviour
{
    [SerializeField] Transform playerTF;

    Rigidbody rb;
    bool popUpSW;
    bool shootSW;
    float timeScale;

    string switchRoot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        //
        switch (switchRoot)
        {
            case "PopUp"://‹N“®
                PopUp();
                break;
            case "Shoot"://í“¬
                Shoot();
                break;
            default:
                Debug.Log("s“®‘I‘ð’†....");
                break;
        }

        timeScale += 1.0f * Time.timeScale;
        /*if (Input.GetButtonDown("Jump")) switchRoot = "PopUp";
        if(rb.velocity.magnitude >= 7)
        {
            switchRoot = "Shoot";
        }*/
        if (Input.GetButtonDown("Jump")) switchRoot = "Shoot";
    }

    void FixedUpdate()
    {
        if (shootSW == true && rb.velocity.magnitude < 50.0f)
            rb.AddForce(transform.forward * 50.0f, ForceMode.Force);
    }

    void PopUp()
    {
        if(popUpSW == false)
        {
            rb.AddForce(transform.up * 20.0f, ForceMode.VelocityChange);
            popUpSW = true;
        }
        rb.velocity += new Vector3(0, -1f, 0);
    }

    void Shoot()
    {
        Quaternion lookRotation = Quaternion.LookRotation(playerTF.transform.position - transform.position, Vector3.up);

        //lookRotation.z = 0;
        //lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        //sVector3 p = new Vector3(0f, 0f, 5);
        shootSW = true;
    }
}
