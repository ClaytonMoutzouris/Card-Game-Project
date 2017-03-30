using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("CardCollection")]
public class CardContainer {

	[XmlArray("Cards")]
	[XmlArrayItem("Card")]
	public List<Card> cards = new List<Card>();

	public static CardContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset> (path);
		XmlSerializer serializer = new XmlSerializer(typeof(CardContainer));

		StringReader reader = new StringReader (_xml.text);

		CardContainer cards = serializer.Deserialize (reader) as CardContainer;

		reader.Close();

		return cards;
	}
}
