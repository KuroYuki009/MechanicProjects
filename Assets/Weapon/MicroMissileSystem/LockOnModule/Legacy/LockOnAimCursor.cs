using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnAimCursor : MonoBehaviour
{
    ////�p�~�ς݁B�@�\�̓X�N���v�g�uLockOnCursorConvert�v�ɓ�������܂����B

    //�ϐ��p
    // bool LockedOnSW;//���b�N�I������Ă��邩�𔻒肷��B

    void Start()
    {

    }


    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy_Cursor" && LockedOnSW == false)
        {
            LockedOnSW = true;
            collision.SendMessage("LockOn");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy_Cursor" && LockedOnSW == true)
        {
            LockedOnSW = false;
            collision.SendMessage("LockOut");
        }
    }*/
}
