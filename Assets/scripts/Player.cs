using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int rotDir = 0; // 0 tokeimawari 1 hantokei
	private int space = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var ang = transform.eulerAngles;
		switch(rotDir){
		case 0:
			ang.z -= 10;
			break;

		case 1:
			ang.z += 10;
			break;
		}
		transform.eulerAngles = ang;

		Vector3 v = transform.localPosition;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			v.x -= 0.05f;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			v.x += 0.05f;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			v.y += 0.05f;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			v.y -= 0.05f;
		}
		if (Input.GetKey (KeyCode.Space)) {
			++space;
		} else {
			space = 0;
		}
		if(space == 1){
			rotDir = (rotDir + 1) % 2;
		}
		transform.localPosition = v;


		// 位置のシータ取得
		float sita = Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);
		float r = Mathf.Sqrt(Mathf.Pow(transform.localPosition.y, 2) + Mathf.Pow(transform.localPosition.x, 2));
		if(r > 4.5f){
			r = 4.5f;
		}

		// 流される
		sita += Mathf.PI * -4f / 180.0f;
		var pos = transform.localPosition;
		pos.x = r * Mathf.Cos(sita);
		pos.y = r * Mathf.Sin(sita);
		transform.localPosition = pos;

	}
}
