using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

	public CardObject card;
	public DropZone hand;
	CardObject[] deck;
	List<CardObject> deckList;
	List<CardObject> handList;
	public CardLoader cardList;
	public List<Card> cards;
	int r;
	// Use this for initialization
	public void Init (Controller control, Hero hero) {
	
		cardList.Init ();
		cards = cardList.cc.cards;
		//deck = new CardObject[cards.Count];
		deckList = new List<CardObject> ();
		handList = new List<CardObject> ();
		CardObject temp;
		for (int i = 0; i < cards.Count; i++) {
			temp = null;
			temp = Instantiate (card, this.transform.position, Quaternion.identity) as CardObject;
			temp.gameObject.name = "CardObject " + i;

			if(i < 5){
				temp.transform.SetParent(hand.transform);
			}else{
				temp.transform.SetParent(this.transform);

			}
			r = Random.Range(0,cards.Count);
			temp.transform.localScale = new Vector3(1,1,1);
			temp.Init (cards[r].name, cards[r].cost, cards[r].mod, cards[r].damage, cards[r].ID, cards[r].type);
			temp.owner = hero;
			temp.gameControl = control;
			//deckList.Add(temp);
			if(i >=5){
				deckList.Add(temp);
				temp.gameObject.SetActive(false);
			} else {
				handList.Add (temp);
			}
		}

	}


	public void Draw(){
		deckList [0].gameObject.SetActive (true);
		handList.Add (deckList[0]);
		deckList [0].transform.SetParent (hand.transform);
		deckList.RemoveAt (0);
		}

	public void Save(){
		//cardCollection.Save(Path.Combine(Application.persistentDataPath, "CardObjectData.xml"));

	}
	
	// Update is called once per frame
	void Update () {
		/*
	if(hand.transform.childCount < 5){
			deck[5].gameObject.SetActive(true);
			deck[5].transform.SetParent(hand.transform);
		}
		*/

	}
}
