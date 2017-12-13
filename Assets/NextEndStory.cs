using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextEndStory : MonoBehaviour {

	Transform transform;
	int flag;
	public GameObject story3,story4,story5;
	public GameObject text3,screen;
	string st1 = "Tuttu almost reached land! Yay! Her efforts never betray her. Now, it is time to look for a nice warm seashore for her lovely babies.";
	string st2 = "89... 90... Whoa! go! Tuttu has deposited 90 eggs! She feels joyful and blessed. She then covers her eggs within sands so that the eggs will eventually hatch.";
	string st3 = "Now she goes home... to the vast sea. Her babies will be missed so dealy by her. Waiting for them to grow up and return to the sea.";

	float timeRemaining;
	// Use this for initialization
	void Start () {
		flag = 1;
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			MoveToNext ();
		}
		timeRemaining -= Time.deltaTime;
	}

	void OnMouseDown(){
		MoveToNext ();
	}

	void MoveToNext(){
		if (flag == 1) {
			screen.GetComponent<SpriteRenderer> ().enabled = true;
			text3.GetComponent<Text> ().text = st1;
		} else if (flag == 2) {
			story3.GetComponent<SpriteRenderer> ().enabled = false;
			story4.GetComponent<SpriteRenderer> ().enabled = true;
			screen.GetComponent<SpriteRenderer> ().enabled = false;
			text3.GetComponent<Text> ().text = "";
		} else if (flag == 3) {
			text3.GetComponent<Text> ().text = st2;
			screen.GetComponent<SpriteRenderer> ().enabled = true;
		} else if (flag == 4) {
			story4.GetComponent<SpriteRenderer> ().enabled = false;
			story5.GetComponent<SpriteRenderer> ().enabled = true;
			screen.GetComponent<SpriteRenderer> ().enabled = false;
			text3.GetComponent<Text> ().text = "";
		} else if (flag == 5) {
			screen.GetComponent<SpriteRenderer> ().enabled = true;
			text3.GetComponent<Text> ().text = st3;
		} else if (flag == 6) {
			text3.GetComponent<Text> ().text = "The End";
		}else {
			Application.LoadLevel("MainMenu");
		}
		flag++;
	}

	void OnMouseOver(){
		//Debug.Log ("Hover");
		transform.localScale = new Vector2 (1.8f, 1.8f);
	}

	void OnMouseExit (){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (1.7f, 1.7f);
	}
}
