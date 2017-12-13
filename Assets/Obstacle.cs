using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	Transform transform;
	Renderer ren;
	BoxCollider2D col;
	Rigidbody2D rg;

	int rand;
	int flagPause;
	float pos1,pos2,pos3,posy;
	// Use this for initialization
	void Start () {
		flagPause = 0;
		transform = this.GetComponent<Transform> ();
		ren = this.GetComponent<Renderer> ();
		col = this.GetComponent<BoxCollider2D> ();
		rg = this.GetComponent<Rigidbody2D> ();
		rg.velocity = new Vector2(-7f,0f);

		pos1 = 1.5f;
		pos2 = -0.5f;
		pos3 = -3.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -7 - ren.bounds.size.x) {
			col.isTrigger = false;
			transform.position = new Vector2(20,transform.position.y);
			rand = Random.Range(1,99);
			rand = rand%3;
			if(rand==0){
				posy = pos1;
			}else if(rand==1){
				posy = pos2;
			}else if(rand==2){
				posy = pos3;
			}
			rand = Random.Range(3,7);
			transform.position = new Vector2(transform.position.x-rand,posy);
		}
		if(flagPause!=1)
			rg.velocity = new Vector2 (-7f, 0f);
	}

	void OnCollisionEnter2D (Collision2D colInfo) {
		if (colInfo.collider.tag == "Player" || colInfo.collider.tag == "Wall") {
			col.isTrigger = true;
			rg.velocity = new Vector2 (-7f, 0f);
		} else if (colInfo.collider.tag == "WallRight") {
			transform.position = new Vector2(transform.position.x-2.25f,transform.position.y);
		}
	}

	public void Pause(){
		flagPause = 1;
	}

	public void Unpause(){
		flagPause = 0;
	}
}
