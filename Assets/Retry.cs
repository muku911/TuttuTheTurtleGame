using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class Retry : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	RectTransform transform;
	public Camera mainCamera;
	public int level;
	// Use this for initialization
	void Start () {
		transform = this.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void OnPointerClick(PointerEventData eventData){
		MoveToNext ();
	}

	public void MoveToNext(){
		if (level == 1)
			Application.LoadLevel ("Main");
		else if (level == 2)
			Application.LoadLevel ("Level 2");
		else if (level == 3)
			Application.LoadLevel ("Level 3");
	}
	
	public void OnPointerEnter(PointerEventData eventData){
		transform.localScale = new Vector2 (1.2f, 1.2f);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		//Debug.Log("Wait");
		transform.localScale = new Vector2 (1f, 1);
	}
	
}
