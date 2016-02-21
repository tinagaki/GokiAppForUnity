using UnityEngine;
using System.Collections;
// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {
	// 移動スピード
	public double speed;
	//
	private bool isWait = false;
	private bool isWalk = false;
	private float right = 0f;
	private float up = 0f;


	void Start () {

		//move (transform.up * -1);
	}
	// Update is called once per frame
	void Update () {
		int move_type= (int)Random.Range (1, 100) ;
		print(move_type);

	   if (this.isWait == false && this.isWalk == false) { //nanimo nai zyoutai
			if (move_type < 96 ) { 
				this.Walk();
			}else{
				StartCoroutine ("Wait");
			}
		}
		//動くフラグがついている場合にに従い動く　（といいはず）
		if(this.isWalk == true){

		}


		// 移動の制限
		Clamp();

	}	
	private void Walk(){
		this.isWalk=true;
//		print("walk!!");
//
//		this.right = (float)Random.Range (-1, 2) * 0.1f;
//		this.up = (float)Random.Range (-1, 2) * 0.1f;
//		
//		transform.Translate (Vector3.right   * this.right);
//		transform.Translate (Vector3.up *  this.up);

		int walk_type= (int)Random.Range (1, 2) ;

		if(walk_type==1){ // 直線タイプ
			this.walkTypeStraight();
		}else if(walk_type==2){//楕円タイプ
			this.walkTypeEllipse();
		}
		//二段階目
		//
		walk_type= (int)Random.Range (1, 3) ;
		if (walk_type == 1) { // 直線タイプ
			this.walkTypeStraight();
		} else if (walk_type == 2) {//楕円タイプ
			this.walkTypeEllipse();
		} else {// 処理しない 
			//return void;
		}
		//(メソッド,秒数)を指定
		//float waitTime=(float)Random.Range (0.1f, 0.7f);
		//Invoke("updateWalk",waitTime);

		this.isWalk=false;

	}
	void updateWalkFlg(){
		//(メソッド,秒数)を指定
		this.isWalk=false;
	}

	private IEnumerator Wait(){
		this.isWait=true;
		float waitTime=(float)Random.Range (0.001f, 0.7f);
		//print (waitTime);
		yield return new WaitForSeconds(waitTime );

		print("wait!!");
		// 2秒間待機
		//yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
//		this.right = (float)Random.Range (-1, 2) * 0.1f;
//		this.up = (float)Random.Range (-1, 2) * 0.1f;
//
//		transform.Translate (Vector3.right   * this.right);
//		transform.Translate (Vector3.up *  this.up);
//
//
//		print("wait2!!");
//		yield return new WaitForSeconds(1);
//
//		//transform.Translate (Vector3.right * (float)Random.Range (-1, 2) * 0.1f);
//		//transform.Translate (Vector3.up * (float)Random.Range (-1, 2) * 0.1f);
//		transform.Translate (Vector3.right   * -this.right);
//		transform.Translate (Vector3.up *  - this.up);
//
//		// 2秒間待機
//		yield return new WaitForSeconds(2);
//		print("wait3!!");
//
		this.isWait=false;
	}
	public void walkTypeStraight(){
		print("walk!!");
		
		this.right = (float)Random.Range (-1, 2) * 0.1f;
		this.up = (float)Random.Range (-1, 2) * 0.1f;
				
		transform.Translate (Vector3.right   * this.right);
		transform.Translate (Vector3.up *  this.up);

		//return void;

	}
	public void walkTypeEllipse(){
		//return void;
	}


	public void setSpeed(int num){
		speed = num;

	}
	// 機体の移動
	public void move (Vector2 direction)
	{
		print ("bbbb");
		//print (speed);
		//speed = Random.Range(0,3)

//		rigidbody2D.velocity = direction * speed;
		Vector2 p = new Vector2 (Random.Range(-5,5),Random.Range(-5,5));
				rigidbody2D.velocity = p;

	}
	public void OnMouseDown(){
		Destroy (gameObject);
	}
	//
	public void Clamp(){
		// 画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		// プレイヤーの座標を取得
		Vector2 pos = transform.position;
		
		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;

	}
}
