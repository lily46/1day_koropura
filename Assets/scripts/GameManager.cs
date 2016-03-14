using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int rotDir = 0; // 0 tokeimawari 1 hantokei

	public int score = 0;
	public int time = 60 * 30;

	public GameObject sanma, hirame, uni;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 20 * 60) {
			if(time % 90 == 0){
				float sita = Mathf.PI * Random.Range (0, 360) / 180;
				float r = Random.Range (2, 4);
				Instantiate(sanma, new Vector3 (r * Mathf.Cos(sita), r * Mathf.Sin(sita), 5), Quaternion.identity);
			}
		} else {
			if(time % 60 == 0){
				float sita = Mathf.PI * Random.Range (0, 360) / 180;
				float r = Random.Range (2, 4);
				Instantiate(sanma, new Vector3 (r * Mathf.Cos(sita), r * Mathf.Sin(sita), 5), Quaternion.identity);
			}

			if(time % 90 == 0){
				float sita = Mathf.PI * Random.Range (0, 360) / 180;
				float r = Random.Range (2, 4);
				Instantiate(hirame, new Vector3 (r * Mathf.Cos(sita), r * Mathf.Sin(sita), 5), Quaternion.identity);
			}
		}

		--time;
	}
}
