using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Application.LoadLevel ("HowToPlay");
	}

	void OnMouseOver(){
		//Debug.Log ("Hover");
		transform.localScale = new Vector2 (0.6f, 0.6f);
	}
	
	void OnMouseExit (){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (0.5f, 0.5f);
	}
}
