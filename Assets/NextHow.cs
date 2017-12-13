using UnityEngine;
using System.Collections;

public class NextHow : MonoBehaviour {

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
		if (flag == 1) {
			how1.GetComponent<SpriteRenderer> ().enabled = false;
			how2.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (flag == 2) {
			Application.LoadLevel("MainMenu");
		} 
		GameObject.Find ("back").GetComponent<BeforeHow>().Plus();
		flag++;
	}

	public void Min(){
		flag--;
		if (flag < 1)
			flag = 1;
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
