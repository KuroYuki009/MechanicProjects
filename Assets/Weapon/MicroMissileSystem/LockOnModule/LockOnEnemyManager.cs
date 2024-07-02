using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockOnEnemyManager : MonoBehaviour
{
    //�G�̃I�u�W�F�N�g�ɐڑ����Ďg�p���܂��B
    [SerializeField] GameObject instLockOnCursor;//�C���X�^���X�����郍�b�N�I�����J�[�\�����w��B
    [SerializeField] RectTransform canvasObject;//�J�[�\�����q�Ƃ��ăC���X�^���X����ׂ̃L�����o�X���w��B

    //�i�[�p
    private GameObject instCursorObject;//���������J�[�\����Object�����i�[����ׂ́B
    LockOnCursorConvert cursorConvertComp;

    //�ϐ��p
    bool cameraBecameSW;
    void Start()
    {
        SetUp();
    }

    
    void Update()
    {
        
    }

    void SetUp()
    {
        //�J�[�\���𐶐����A���̃I�u�W�F�N�g����n���B
        instCursorObject = Instantiate(instLockOnCursor,canvasObject);
        cursorConvertComp = instCursorObject.GetComponent<LockOnCursorConvert>();
        cursorConvertComp.targetObject = this.gameObject;
        //locc = null;
    }

    private void OnBecameInvisible()
    {
        cursorConvertComp.objectBecameSW = false;
        cursorConvertComp.SendMessage("CursorRendering");
        Debug.Log("�f���Ă��Ȃ�");
    }

    // 
    private void OnBecameVisible()
    {
        cursorConvertComp.objectBecameSW = true;
        cursorConvertComp.SendMessage("CursorRendering");
        Debug.Log("�f���Ă���");
    }
}
