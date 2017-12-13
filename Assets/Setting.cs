using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Application.LoadLevel ("Credit");
	}

	void OnMouseOver(){
		//Debug.Log ("Hover");
		transform.localScale = new Vector2 (1.1f, 1.1f);
	}
	
	void OnMouseExit (){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (1f, 1f);
	}
}
