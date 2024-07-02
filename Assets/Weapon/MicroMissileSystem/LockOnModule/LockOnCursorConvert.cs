using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockOnCursorConvert : MonoBehaviour
{
	////カーソルに接続して使用します。
	//RectTransformConvert用
	RectTransform rectTransform = null;
	Transform target;
	public GameObject targetObject;

	//格納用
	[SerializeField]Image rd;
	bool transparentZero;
	MicroMissileGenerator mmg = null;

	//変数用
	bool LockedOnSW;

	public bool cursorBecameSW;//このカーソルが描写の許可があるかのswitch。
	public bool objectBecameSW;//本体のオブジェクトが描写の許可があるかのswitch。
	void Start()
	{
		target = targetObject.GetComponent<Transform>();
		rectTransform = GetComponent<RectTransform>();
		rd = GetComponent<Image>();
		rd.enabled = false;
	}

	void Update()
	{
		//RectTransformConvert用
		rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);

		if (targetObject == null)//もし連携されているオブジェクトが消えた場合、このカーソルも消滅する。
			Destroy(this.gameObject);
	}

	/*public void LockOn()
    {
		srRd.enabled = true;
		Debug.Log("ロックオン");
	}

	public void LockOut()
    {
		srRd.enabled = false;
		Debug.Log("カーソルロスト");
	}*/

	//プレイヤーが起動したロックオンエイムカーソルのスプライトについているタグ"LockOnAimCursor"に反応したら描写を行う。
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "LockOnAimCursor" && LockedOnSW == false)
		{
			//描写する
			LockedOnSW = true;

			cursorBecameSW = true;//ここで描写切り替え
			CursorRendering();

			if (cursorBecameSW == true && objectBecameSW == true)//オブジェクトの描写とカーソルの描写がされている時だけ許可する。
			{
				//ヒットしたAimCursorについているミサイルジェネレーターにターゲット情報を渡す。
				mmg = collision.GetComponent<MicroMissileGenerator>();
				mmg.lockOnObjs.Add(target);
			}
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "LockOnAimCursor" && LockedOnSW == true)
		{
			//非描写にする
			LockedOnSW = false;

			cursorBecameSW = false;//ここで描写切り替え
			CursorRendering();


			//渡した情報を削除させる。
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
