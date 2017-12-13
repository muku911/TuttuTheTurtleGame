using UnityEngine;
using System.Collections;

public class BeforeHow : MonoBehaviour {

	Transform transform;
	int flag;
	public GameObject how1,how2;
	// Use this for initialization
	void Start () {
		flag = 1;
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown(){
		MoveToNext ();
	}
	
	void MoveToNext(){
		if (flag == 2) {
			how1.GetComponent<SpriteRenderer> ().enabled = true;
			how2.GetComponent<SpriteRenderer> ().enabled = false;
		}
		GameObject.Find ("next").GetComponent<NextHow>().Min();
		flag--;
	}

	public void Plus(){
		flag++;
		if (flag > 2)
			flag = 2;
	}

	void OnMouseOver(){
		//Debug.Log ("Hover");
		transform.localScale = new Vector2 (1.4f, 1.4f);
	}
	
	void OnMouseExit (){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (1.3f, 1.3f);
	}
}
