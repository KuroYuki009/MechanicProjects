using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchColliderConvert : MonoBehaviour
{
    ////���̃X�N���v�g�͕ʃI�u�W�F�N�g��Trigger�擾�p�̃X�N���v�g�ł��B
    // > �ʃX�N���v�g�ŃA�^�b�`���āuonTriggerSW�v�ϐ����擾���Ă��������B
    // > �^�O�w��ɂ��uPlayer�v�ɔ������܂��B
    public bool onTriggerSW;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        onTriggerSW = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        onTriggerSW = false;
    }
}
