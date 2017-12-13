using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextStory : MonoBehaviour {

	Transform transform;
	int flag;
	public int story;
	public GameObject text3;
	string st1 = "Chelonia mydas, or what we used to call as green sea turtle, is one of endagered animals. Green sea turtles migrate long distances to reach their spawning grounds. That is the only natural way to keep them from extinction. Somewhere in the ocean, at Pacific Ocean, there is a female green sea turtle named Tuttu. She needs to go in a long journey. Yes, she carries her lovely babies inside eggs within her. The journey begins...";
	string st2 = "Tuttu realizes that she had been talking long way over weeks. She successfully overcame many obstacles that hampered her journey, but who knows? It may still haunts her journey. No matter what happens, she will not stop her going.";
	string st3 = "How far the way she has been taking? Perhaps it is almost a thousand kilometer. Tuttu finds herself she swimming in a shallow water. It means land is not far away from her!";
	// Use this for initialization
	void Start () {
		flag = 1;
		transform = this.GetComponent<Transform> ();
		if(story==1)
			text3.GetComponent<Text> ().text = st1;
		else if(story==2)
			text3.GetComponent<Text> ().text = st2;
		else if(story==3)
			text3.GetComponent<Text> ().text = st3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			MoveToNext ();
		}
	}
	
	void OnMouseDown(){
		MoveToNext ();
	}
	
	void MoveToNext(){
		if (story == 1)
			Application.LoadLevel ("Main");
		else if (story == 2)
			Application.LoadLevel ("Level 2");
		else if (story == 3)
			Application.LoadLevel ("Level 3");
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
