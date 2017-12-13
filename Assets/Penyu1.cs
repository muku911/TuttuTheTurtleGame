using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Penyu1 : MonoBehaviour {

	Transform transform;
	public GameObject life1,life2,life3,shield;
	public GameObject boxKalah,textTry,buttonRetry,buttonQuit;
	public Sprite sprite1,sprite2,spriteMati;
	SpriteRenderer sp1,sp2,sp3,spShield;
	int life;
	int isShield;
	int flagPause;
	public AudioSource popBubbleEffect;
	public AudioSource hitEffect;
	Rigidbody2D rg;


	// Use this for initialization
	void Start () {
		life = 3;
		isShield = 0;
		flagPause = 0;
		transform = this.GetComponent<Transform> ();
		rg = this.GetComponent<Rigidbody2D> ();
		sp1 = life1.GetComponent<SpriteRenderer> ();
		sp2 = life2.GetComponent<SpriteRenderer> ();
		sp3 = life3.GetComponent<SpriteRenderer> ();
		spShield = shield.GetComponent<SpriteRenderer> ();
		spShield.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (flagPause == 1) {
			rg.velocity = new Vector2(0,0);
		}
	}

	void OnCollisionEnter2D (Collision2D colInfo) {
		if (colInfo.collider.tag == "Obstacle") {
			colInfo.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			hitEffect.Play ();
			if(isShield==1){
				isShield = 0;
				popBubbleEffect.Play ();
				spShield.enabled = false;
			}else{
				life--;
			}
			if (life == 2) {
				sp3.sprite = sprite2;
			} else if (life == 1) {
				sp2.sprite = sprite2;
			} else if (life == 0) {
				GameObject.Find ("_Master").GetComponent<Master>().EndMultiply();
				sp1.sprite = sprite2;
				this.GetComponent<SpriteRenderer> ().sprite = spriteMati;
				makeBoxKalah();
				//this.GetComponent<Animator>().SetInteger("isDead",1);
				this.GetComponent<Animator>().enabled = false;
				this.GetComponent<BoxCollider2D>().enabled = false;
				rg.gravityScale = 0;
				transform.Rotate(new Vector3(0,0,-90f));
				rg.velocity = new Vector2(0,-5f);		
			}
		} 
		float x = transform.position.x;
		float y = transform.position.y;
		if (x <= -5.5f) {
			transform.position = new Vector2(-5.5f,y);
		}
	}

	void makeBoxKalah(){
		boxKalah.GetComponent<Image> ().enabled = true;
		textTry.GetComponent<Text> ().enabled = true;
		buttonRetry.GetComponent<Image> ().enabled = true;
		buttonQuit.GetComponent<Image> ().enabled = true;
		buttonRetry.GetComponent<Button> ().enabled = true;
		buttonQuit.GetComponent<Button> ().enabled = true;
	}

	public void GetShield(){
		isShield = 1;
		spShield.enabled = true;
	}

	public void GetLife(){
		life++;
		if (life > 3)
			life = 3;
		if (life == 3) {
			sp3.sprite = sprite1;
		} else if (life == 2) {
			sp2.sprite = sprite1;
		}
	}

	public void Pause(){
		flagPause = 1;
		//rg.gravityScale = 0;
	}

	public void Unpause(){
		flagPause = 0;
	}
}

