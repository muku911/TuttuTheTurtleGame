using UnityEngine;
using System.Collections;

public class GoToMenu : MonoBehaviour {

	Transform transform;
	int flag;
	// Use this for initialization
	void Start () {
		flag = 1;
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel ("MainMenu");
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
