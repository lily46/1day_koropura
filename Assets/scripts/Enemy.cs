using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int rotDir = 0; // 0 tokeimawari 1 hantokei
	private int space = 0;
	public bool hitCheck = false;
	public float chakusuiTime = 100f;
	private Player player;
	// Use this for initialization

	void OnTriggerEnter2D(Collider2D col){
		if(hitCheck){
			if(col.tag == "Player"){
				if(player.rotDir == rotDir){
					Destroy(gameObject);
				}
			}
		}
	}

	// Playerを探す
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player>();
		hitCheck = false;
		rotDir = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (hitCheck) {
			var ang = transform.eulerAngles;
			switch (rotDir) {
			case 0:
				ang.z -= 10;
				break;

			case 1:
				ang.z += 10;
				break;
			}
			transform.eulerAngles = ang;

			// 位置のシータ取得
			float sita = Mathf.Atan2 (transform.localPosition.y, transform.localPosition.x);
			float r = Mathf.Sqrt (Mathf.Pow (transform.localPosition.y, 2) + Mathf.Pow (transform.localPosition.x, 2));
			if (r > 4.5f) {
				r = 4.5f;
			}

			// 流される
			sita += Mathf.PI * -4f / 180.0f;
			var pos = transform.localPosition;
			pos.x = r * Mathf.Cos (sita);
			pos.y = r * Mathf.Sin (sita);
			transform.localPosition = pos;
		} else {
			// 着水
			var pos = transform.localPosition;
			pos.z -= 5.0f / chakusuiTime;
			var scale = transform.localScale;
			scale.x -= 1.0f / chakusuiTime;
			scale.y -= 1.0f / chakusuiTime;
			if(pos.z <= 0){
				pos.z = 0;
				GetComponent<Renderer>().GetComponent<SpriteRenderer>().sortingLayerName = "default";
				hitCheck = true;
			}
			transform.localPosition = pos;
			transform.localScale = scale;
		}

	}
}
