using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//gui�g���\��B

[CreateAssetMenu(fileName = "alphaCustomDate")]
public class alphaCustomEdit : ScriptableObject
{
    public List<CustomDate> CcstomDate;

    [System.Serializable]
    public class CustomDate
    {
        ////�t�@�C�������Q�Ƃ���ۂɂ�int�^�ŎQ�Ƃ���K�v������B(�����I�ɂ�string�^�ŎQ�Əo����悤�ɂ���B)
        public string Name;//���O�B
        public string IconString;//�Q�Ƃ���UI�X�v���C�g�̃��\�[�X���t�@�����X���L�ځB
        [Multiline(4)]public string Commentary;//�������B�Q�[�����Ŏ��o�I�ɏ����������ۂɎg���B
        public string ReferenceString;//�Q�Ƃ���v���n�u�̃��\�[�X���t�@�������L�ځB

        ////�v���n�u���̂Ƀ_���[�W���l�Ȃǂ���������ׁA�����炩��v�f����������K�v�������Ȃ����B
        //public float PointValue;//�ێ����Ă��鐔�l�B�U���n�Ɏg���ꍇ�ɂ͐��l�Ƀ}�C�i�X��t����K�v������B

    }
}
