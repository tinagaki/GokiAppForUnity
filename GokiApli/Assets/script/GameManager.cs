using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {
		MakeEnemys ();

		// Spaceshipコンポーネントを取得

		// ローカル座標のY軸のマイナス方向に移動する
//		enemys.Move (transform.up * -1);

	}
	// Update is called once per frame
	void Update () {
	  
	}
	void MakeEnemys(){
		for(int i = 0;i<20;i++){

			GameObject enemy = (GameObject)Instantiate (EnemyPrefab);

			Vector3 p = enemy.transform.position;
		
			p.x = Random.Range(-2,2);
			p.y = Random.Range(-4,4);
			enemy.transform.position = p;
		//enemys = GetComponent<enemy> ();
			Enemy enemyObj = enemy.GetComponent <Enemy>();
			enemyObj.speed = 0.5;

		}

	}



}
