using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockOnCursorConvert : MonoBehaviour
{
	////�J�[�\���ɐڑ����Ďg�p���܂��B
	//RectTransformConvert�p
	RectTransform rectTransform = null;
	Transform target;
	public GameObject targetObject;

	//�i�[�p
	[SerializeField]Image rd;
	bool transparentZero;
	MicroMissileGenerator mmg = null;

	//�ϐ��p
	bool LockedOnSW;

	public bool cursorBecameSW;//���̃J�[�\�����`�ʂ̋������邩��switch�B
	public bool objectBecameSW;//�{�̂̃I�u�W�F�N�g���`�ʂ̋������邩��switch�B
	void Start()
	{
		target = targetObject.GetComponent<Transform>();
		rectTransform = GetComponent<RectTransform>();
		rd = GetComponent<Image>();
		rd.enabled = false;
	}

	void Update()
	{
		//RectTransformConvert�p
		rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);

		if (targetObject == null)//�����A�g����Ă���I�u�W�F�N�g���������ꍇ�A���̃J�[�\�������ł���B
			Destroy(this.gameObject);
	}

	/*public void LockOn()
    {
		srRd.enabled = true;
		Debug.Log("���b�N�I��");
	}

	public void LockOut()
    {
		srRd.enabled = false;
		Debug.Log("�J�[�\�����X�g");
	}*/

	//�v���C���[���N���������b�N�I���G�C���J�[�\���̃X�v���C�g�ɂ��Ă���^�O"LockOnAimCursor"�ɔ���������`�ʂ��s���B
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "LockOnAimCursor" && LockedOnSW == false)
		{
			//�`�ʂ���
			LockedOnSW = true;

			cursorBecameSW = true;//�����ŕ`�ʐ؂�ւ�
			CursorRendering();

			if (cursorBecameSW == true && objectBecameSW == true)//�I�u�W�F�N�g�̕`�ʂƃJ�[�\���̕`�ʂ�����Ă��鎞����������B
			{
				//�q�b�g����AimCursor�ɂ��Ă���~�T�C���W�F�l���[�^�[�Ƀ^�[�Q�b�g����n���B
				mmg = collision.GetComponent<MicroMissileGenerator>();
				mmg.lockOnObjs.Add(target);
			}
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "LockOnAimCursor" && LockedOnSW == true)
		{
			//��`�ʂɂ���
			LockedOnSW = false;

			cursorBecameSW = false;//�����ŕ`�ʐ؂�ւ�
			CursorRendering();


			//�n���������폜������B
			mmg.lockOnObjs.Remove(target);
		}
	}

	void CursorRendering()
    {
		if(cursorBecameSW == false || objectBecameSW == false)
        {
			rd.enabled = false;
		}
		else if(cursorBecameSW == true && objectBecameSW == true)
        {
			rd.enabled = true;
		}
    }
}
