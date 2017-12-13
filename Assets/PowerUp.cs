using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	Transform transform;
	Renderer ren;
	BoxCollider2D col;
	Rigidbody2D rg;
	SpriteRenderer spriteRen;
	public AudioSource getBubbleEffect;

	public Sprite sp1,sp2,sp3;
	int flag;
	int rand;
	float pos1,pos2,pos3,posx;
	int flagPause;

	// Use this for initialization
	void Start () {
		flag = 1;
		flagPause = 0;
		transform = this.GetComponent<Transform> ();
		ren = this.GetComponent<Renderer> ();
		col = this.GetComponent<BoxCollider2D> ();
		rg = this.GetComponent<Rigidbody2D> ();
		spriteRen = this.GetComponent<SpriteRenderer> ();
		rg.velocity = new Vector2(0f,5f);

		pos1 = -4.25f;
		pos2 = 0f;
		pos3 = 4f;
	}
	
	// Update is called once per frame
	void Update () {
		if(flagPause !=1)
			rg.velocity = new Vector2(0f,3f);
	}

	void OnCollisionEnter2D (Collision2D colInfo) {
		if (colInfo.collider.tag == "Player") {
			getBubbleEffect.Play ();
			var linkToScriptB = GameObject.Find ("Penyu").GetComponent<Penyu1>();
			if(flag == 1){
				linkToScriptB.GetShield();
			}else if(flag==2){
				DoubleTheScore();
			}else if(flag==3){
				linkToScriptB.GetLife();
			}
		}
		if (colInfo.collider.tag == "Player" || colInfo.collider.tag == "Obstacle" || colInfo.collider.tag == "WallTop") {
			rand = Random.Range(1,99);
			rand = rand%3;
			if(rand==0){
				posx = pos1;
			}else if(rand==1){
				posx = pos2;
			}else if(rand==2){
				posx = pos3;
			}
			rand = Random.Range (1,4);
			if(rand==1){
				spriteRen.sprite = sp1;
			}else if(rand == 2){
				spriteRen.sprite = sp2;
			}else if(rand >= 3){
				spriteRen.sprite = sp3;
			}
			flag = rand;
			rand = Random.Range(-60,-20);
			transform.position = new Vector2(posx,rand);
		} else if (colInfo.collider.tag == "WallBottom") {
			transform.position = new Vector2(transform.position.x,transform.position.y+2.5f);
		}
	}

	void DoubleTheScore(){
		GameObject.Find ("_Master").GetComponent<Master>().Multiply();
	}

	public void Pause(){
		flagPause = 1;
	}

	public void Unpause(){
		flagPause = 0;
	}
}
