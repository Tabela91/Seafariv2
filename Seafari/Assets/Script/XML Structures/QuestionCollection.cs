using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

[XmlRoot ("seafari")]
public class QuestionCollection {

	[XmlArray ("questions"), XmlArrayItem ("question")]
	public List <Question> question;


	public List <Question> GetQuestions (int amount) {

		List <Question> shuffled = question;
		// Take care to randomize the array
		shuffled.RemoveRange (amount, shuffled.Count - amount);

		return shuffled;

	}

}
