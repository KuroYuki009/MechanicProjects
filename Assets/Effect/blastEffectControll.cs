using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastEffectControll : MonoBehaviour
{
    float ts;
    void Update()
    {
        if(ts >= 0.2f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ts += Time.deltaTime * 1.0f;
        }
    }
}
