using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

[XmlRoot ("seafari")]
public class QuestionCollection {

	[XmlArray ("questions"), XmlArrayItem ("question")]
	public List <Question> question;
    public List<Fish> fishes;
    /*
    [XmlArray("fishes"), XmlArrayItem("fish")]
    public List<Fish> fish;

    public List<Fish> GetFish (int amount)
    {
        List<Fish> fishList = fish;

        return fishList;
    }
    */
	public List <Question> GetQuestions (int amount) {

		List <Question> shuffled = question;
        //List < Fish > fish = fishes;
        // Take care to randomize the array
		shuffled.RemoveRange (amount, shuffled.Count - amount);

		return shuffled;


	}

}
