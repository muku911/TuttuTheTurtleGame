using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class Quit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPointerClick(PointerEventData eventData){
		MoveToNext ();
	}
	
	public void MoveToNext(){
		Application.LoadLevel ("MainMenu");
	}
	
	public void OnPointerEnter(PointerEventData eventData){
		transform.localScale = new Vector2 (1.2f, 1.2f);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (1f, 1);
	}
}
