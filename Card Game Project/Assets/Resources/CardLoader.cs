using UnityEngine;
using System.Collections;

public class CardLoader : MonoBehaviour {

	public const string path = "cards";
	public CardContainer cc;
	// Use this for initialization
	public void Init() {
		cc = CardContainer.Load (path);

		foreach (Card card in cc.cards) {
			print (card.name);
			print (card.cost);
		}
	
	}
	

}
