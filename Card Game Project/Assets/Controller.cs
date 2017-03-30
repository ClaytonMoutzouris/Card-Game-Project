using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public Deck deckFab;
	public Deck deck;
	public DropZone hand;
	public Canvas canvas;
	public CardObject selected;
	public Hero hero;
	public Hero p1;
	public Hero p2;
	// Use this for initialization
	void Start () {
		p1 = Instantiate (hero, new Vector3(100, 100, 0), Quaternion.identity) as Hero;
		p1.transform.SetParent (canvas.gameObject.transform);

		deck = Instantiate (deckFab, this.transform.position, Quaternion.identity) as Deck;
		deck.transform.SetParent (canvas.gameObject.transform);
		deck.transform.localPosition = new Vector3 (330, -119, 0);
		deck.transform.localScale = new Vector3(1,1,1);
		deck.hand = hand;
		deck.Init (this, p1);
		p1.Init (15, 2, deck);

	}

	// Update is called once per frame
	void Update () {
	if (selected != null)
			Debug.Log (selected.getName() + " is selected");


		if(Input.GetKeyDown("space")){
			p1.startTurn();
		}
	}
}
