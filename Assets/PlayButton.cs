using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel("Story1");
	}

	void OnMouseOver(){
		//Debug.Log ("Hover");
		transform.localScale = new Vector2 (0.9f, 0.9f);
	}
	
	void OnMouseExit (){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (0.8f, 0.8f);
	}
}
