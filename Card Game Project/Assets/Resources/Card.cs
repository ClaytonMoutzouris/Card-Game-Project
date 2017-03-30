using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


public class Card {


	[XmlAttribute("name")]
	public string name;

	[XmlElement("Damage")]
	public int damage;

	[XmlElement("Cost")]
	public int cost;

	[XmlElement("Mod")]
	public string mod;

	[XmlElement("Rarity")]
	public int rarity;

	[XmlElement("CardID")]
	public int ID;

	[XmlElement("Function")]
	public string func;

	[XmlElement("Type")]
	public string type;
}
