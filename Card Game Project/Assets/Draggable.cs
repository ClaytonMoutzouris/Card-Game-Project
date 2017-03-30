using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
	Vector2 difference;
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	public GameObject placeholder = null;
	public CardObject cOb;

	void Awake(){
		cOb = GetComponent<CardObject>();
	}


	public void OnPointerEnter(PointerEventData eventData){



		if (eventData.pointerDrag != null)
			return;

		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent <LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent <LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;
		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex());
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent (this.transform.parent.parent);

		transform.localScale = new Vector3 (1.5f, 1.5f, 1.0f);
	}
	
	public void OnPointerExit(PointerEventData eventData){
		if (eventData.pointerDrag != null)
			return;

		this.transform.SetParent(parentToReturnTo);
		if (placeholder != null) {
			this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
			Destroy (placeholder);
		}
		transform.localScale = new Vector3 (1, 1, 1);
	}

	public void OnBeginDrag(PointerEventData eventData){
		if (cOb.play () == false) {
			eventData.pointerDrag = null;
			return;
		}

		if (placeholder == null) {

		

			placeholder = new GameObject ();
			placeholder.transform.SetParent (parentToReturnTo);
		
			LayoutElement le = placeholder.AddComponent<LayoutElement> ();
			le.preferredWidth = this.GetComponent <LayoutElement> ().preferredWidth;
			le.preferredHeight = this.GetComponent <LayoutElement> ().preferredHeight;
			le.flexibleWidth = 0;
			le.flexibleHeight = 0;

			placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
		}
		
		difference = new Vector3 (this.transform.position.x - eventData.position.x, this.transform.position.y - eventData.position.y, 0) ;
		//parentToReturnTo = this.transform.parent;
		//placeholderParent = parentToReturnTo;
		//this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		cOb.isSelected ();
	}


	public void OnDrag(PointerEventData eventData){
		/*
		if (cOb.play () == false) {
			
			return;
		}
*/
		this.transform.position = eventData.position + difference;

		if (placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent (placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for (int i = 0; i< placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild (i).position.x){
				newSiblingIndex = i;
				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex){
					newSiblingIndex--;
				}
				break;
			}
		}
		placeholder.transform.SetSiblingIndex (newSiblingIndex);

	}

	public void OnEndDrag(PointerEventData eventData){
		
		this.transform.SetParent(parentToReturnTo);
		if (placeholder != null) {
			this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
		}
		transform.localScale = new Vector3 (1, 1, 1);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		Destroy (placeholder);
		cOb.unSelected ();
	}

}
