using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

	private int cost;
	private string name;
	public Text[] texts;
	public Sprite[] sprites;
	int damage, idnum;
	string type;
	public Image[] images;
	public Hero owner;
	public bool playable;
	public Controller gameControl;
	// Use this for initialization
	public void Init(string nameL, int costL, string mL, int dmg, int id, string type){
		setColor (type);
		name = nameL;
		cost = costL;
		damage = dmg;
		idnum = id;
		texts = GetComponentsInChildren<Text> ();
		texts [0].text = name;
		texts [1].text = "Mod: " + mL + "\nDamage: " + dmg;
		texts[2].text = "" + cost;

		images = GetComponentsInChildren<Image> ();
		images [1].sprite = sprites[(id-1)];
	}

	public void setColor(string t){
		if (t == "Dark") {
			this.GetComponent<Image> ().color = new Color (0.545098f, 0.0f, 0.545098f);
		} else if (t == "Steel") {
			this.GetComponent<Image> ().color = new Color (0.662745f, 0.662745f, 0.662745f);
		} else if (t == "Fire") {
			this.GetComponent<Image> ().color = new Color (1.0f, 0.270588f, 0.0f);
		} else if (t == "Ice") {
			this.GetComponent<Image> ().color = new Color (0.282353f, 0.819608f, 0.8f);
		}
	}
	public bool play(){
		if (owner.energy > 0) {

			//owner.energy--;
			playable = true;
			return true;

		}
		playable = false;
		return false;

	}

	public void playCard (){
		owner.setHealth (owner.health - damage);
		owner.setEnergy(owner.energy - 1);
	}

	public void isSelected(){
		gameControl.selected = this;
	}

	public void unSelected(){
		gameControl.selected = null;

	}

	public string getName(){
		return name;
	}
	
	public void setName(string n){
		name = n;
	}

	public int getCost(){
		return cost;
	}

	public void setCost(int c){
		cost = c;
	}
	
	// Update is called once per frame

}
