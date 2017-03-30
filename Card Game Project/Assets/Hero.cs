using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Hero : MonoBehaviour {


	public int health;
	public int energy;
	public Text text;
	public Deck deck;

	// Use this for initialization
	public void Init (int h, int e, Deck d) {
		health = h;
		energy = e;
		deck = d;
	}

	public void startTurn(){
		setEnergy (energy+1);
		deck.Draw ();
	}

	public void setHealth(int h){
		health = h;
		setText ();
	}

	public void setEnergy(int e){
		energy = e;
		setText();
	}

	public void setText(){
		text.text = "Health: " + health + "\nEnergy: " + energy;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
